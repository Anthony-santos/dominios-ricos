using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Service;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handler;

public class SubscriptionHandler : 
    Notifiable<Notification>,
    IHandler<CreateBoletoSubscriptionCommand>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IEmailService _emailService;
    
    public SubscriptionHandler(IStudentRepository studentRepository, IEmailService emailService)
    {
        _studentRepository = studentRepository;
        _emailService = emailService;
    }
    public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
    {
        // Fail Fast Validation
        command.Validate();
        if (!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, "Não foi possível realizar sua assinatura");
        }

        // Verificar de Domcumento já esta cadastrao
        if (_studentRepository.DocumentExists(command.DocumentNumber))
            AddNotification("Document", "Este CPF já está em uso");
            
        // Verificar de Email já esta cadastrao
        if (_studentRepository.EmailExists(command.Email))
            AddNotification("Email", "Este Email já está em uso");
            
        // Gerar VOs
        var name = new Name(command.FirstName, command.LastName);
        var document = new Document(command.DocumentNumber, EDocumentType.CPF);
        var address = new Address(command.Street, command.Number, command.Neiborhood, command.City, command.State, command.Country, command.ZipCode);
        var email = new Email(command.Email);
        
        // Gerar Entidades
        var student = new Student(name, document, email);
        var subscription = new Subscription(DateTime.Now.AddMonths(1));
        var payment = new BoletoPayment(command.PaidDate, command.ExpireDate, command.Total, command.TotalPaid, command.Payer, new Document(command.PayerDocumentNumber, command.PayerDocumentType), address, email, command.BarCode, command.BoletoNumber);

        // Relacionamento
        subscription.AddPayment(payment);
        student.AddSubscription(subscription);
        
        // Agrupar Validações
        AddNotifications(name, document, address, email, student, subscription, payment);
        
        // Checar as notificações
        if (!IsValid)
            return new CommandResult(false, "Não foi possível realizar sua assinatura");
        
        // Salvar informações
        _studentRepository.CreateSubscription(student);
        
        // Enviar email de boas vindas
        _emailService.sent(student.Name.ToString(), student.Email.Address, "Bem-vindo", "Sua assínatura foi realizada com sucesso.");
        
        // Retornar informações
        return new CommandResult(true, "Assinatura realizada com sucesso");
    }
}