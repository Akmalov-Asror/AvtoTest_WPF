using Autoauto.Options;
using Avtoauto.Models;

namespace Avtoauto.Databases;

public class TicketDatabase
{
    public List<Ticket> UserTickets { get; set; }

    public TicketDatabase()
    {
        UserTickets = new List<Ticket>();
    }
    public Ticket CreateTicket()
    {
        return new Ticket(CreateExamTicket());


    }

    public List<QuestionEntity> CreateExamTicket()
    {
        int randomNumber = new Random().Next(0, GetTicketsCount());
        var questions = Database.Db.QuestionsDb.CreateTicket(randomNumber * TicketsSettings.TicketQuestionsCount, TicketsSettings.TicketQuestionsCount);
        return new List<QuestionEntity>(questions);
    }

    public int GetTicketsCount()
    {
        return Database.Db.QuestionsDb.Questions.Count / TicketsSettings.TicketQuestionsCount;
    }
}