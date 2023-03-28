using Microsoft.Data.Sqlite;

namespace Codecool.BruteForce.Users.Repository;

public class CrackedUserRepository : ICrackedUserRepository
{
    private readonly string _dbFilePath;

    public CrackedUserRepository(string dbFilePath)
    {
        _dbFilePath = dbFilePath;
    }

    private SqliteConnection GetPhysicalDbConnection()
    {
        var dbConnection = new SqliteConnection($"Data Source ={_dbFilePath};Mode=ReadWrite");
        dbConnection.Open();
        return dbConnection;
    }

    private void ExecuteNonQuery(string query)
    {
        using var connection = GetPhysicalDbConnection();
        using var command = GetCommand(query, connection);
        command.ExecuteNonQuery();
    }

    private static SqliteCommand GetCommand(string query, SqliteConnection connection)
    {
        return new SqliteCommand
        {
            CommandText = query,
            Connection = connection,
        };
    }
    
    public void Add(string password, TimeSpan elapsedTime)
    {
        var strElapsedTime = elapsedTime.ToString();
        var query = $"INSERT INTO crackedUsers(password, elapsedTime) VALUES('{password}','{strElapsedTime}')";
        ExecuteNonQuery(query);
    }
    
    public void DeleteAll()
    {
        var query = "DELETE FROM crackedUsers";
        ExecuteNonQuery(query);
    }
}