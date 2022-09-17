using Autoauto.Models;
using Avtoauto.Models;
using Newtonsoft.Json;

namespace Avtoauto.Databases;

public class Database
{
    private const string UsersJsonPath = "JsonData/users.json";
    private const string QuestionsJsonPath = "JsonData/uzlotin.json";

    private static Database _database;
    public static Database Db
    {
        get
        {
            if (_database == null)
            {
                _database = new Database();
            }

            return _database;
        }
    }

    public Database()
    {
        QuestionsDb = new QuestionsDatabase(ReadQuestionsJson());
        TicketDb = new TicketDatabase();
    }

    public QuestionsDatabase QuestionsDb;
    public TicketDatabase TicketDb;
    private List<QuestionEntity> ReadQuestionsJson()
    {
        if (!File.Exists(QuestionsJsonPath)) return new List<QuestionEntity>();
        var json = File.ReadAllText(QuestionsJsonPath);

        try
        {
            return JsonConvert.DeserializeObject<List<QuestionEntity>>(json);
        }
        catch
        {
            System.Console.WriteLine("Cannot deserialize questions json.");
            return new List<QuestionEntity>();
        }
    }

}