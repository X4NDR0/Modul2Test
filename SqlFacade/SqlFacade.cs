using System.Data.SqlClient;

namespace Modul2Test2.SqlFacade
{
    public class SqlFacade : ISqlFacade
    {
        private string _connectionString = "Data Source=DESKTOP-QS7CCGF\\SQLEXPRESS;Initial Catalog=Modul2Test2;Integrated Security=true";

        public int AddTask(Zadatak task)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                int id = 0;
                sqlConnection.Open();
                string command = "insert into dbo.Zadatak(radnik_id,naslov,procenjeno_vreme,tezina,opis,stanje) values(@workerId,@naslov,@procenjenoVreme,@tezina,@opis,@stanje) select scope_identity()";
                SqlCommand cmd = new SqlCommand(command, sqlConnection);
                cmd.Parameters.AddWithValue("@workerId", task.WorkerID);
                cmd.Parameters.AddWithValue("@naslov", task.Title);
                cmd.Parameters.AddWithValue("@procenjenoVreme", task.EstimatedTime);
                cmd.Parameters.AddWithValue("@tezina", task.Difficulty);
                cmd.Parameters.AddWithValue("@opis", task.Description);
                cmd.Parameters.AddWithValue("@stanje", task.Status);
                id = Convert.ToInt32(cmd.ExecuteScalar()); ;
                return id;
            }
        }

        public List<Employee> GetAllEmployees()
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                List<Employee> employees = new List<Employee>();
                sqlConnection.Open();
                string command = "select * from dbo.Radnik";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = int.Parse(reader["radnik_id"].ToString());
                        string nameAndSurname = reader["ime_i_prezime"].ToString();
                        string workplace = reader["radno_mesto"].ToString();
                        Employee employee = new Employee { ID = id, NameAndSurname = nameAndSurname, Workplace = workplace };
                        employees.Add(employee);
                    }
                }
                return employees;
            }
        }

        public List<Zadatak> GetAllTasks()
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                List<Zadatak> tasks = new List<Zadatak>();
                sqlConnection.Open();
                string command = "select * from dbo.Zadatak";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int taskId = int.Parse(reader["zadatak_id"].ToString());
                        int workerId = int.Parse(reader["radnik_id"].ToString());
                        string title = reader["naslov"].ToString();
                        int estimatedTime = int.Parse(reader["procenjeno_vreme"].ToString());
                        int difficulty = int.Parse(reader["tezina"].ToString());
                        string description = reader["opis"].ToString();
                        string status = reader["stanje"].ToString();
                        Zadatak task = new Zadatak { ID = taskId, WorkerID = workerId, Title = title, EstimatedTime = estimatedTime, Difficulty = difficulty, Description = description, Status = status };
                        tasks.Add(task);
                    }
                }
                return tasks;
            }
        }

        public Zadatak GetTaskByID(int taskId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                Zadatak task = null;
                sqlConnection.Open();
                string command = "select * from dbo.Zadatak where zadatak_id=@taskId";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlCommand.Parameters.AddWithValue("taskId", taskId);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = int.Parse(reader["zadatak_id"].ToString());
                        int workerId = int.Parse(reader["radnik_id"].ToString());
                        string title = reader["naslov"].ToString();
                        int estimatedTime = int.Parse(reader["procenjeno_vreme"].ToString());
                        int difficulty = int.Parse(reader["tezina"].ToString());
                        string description = reader["opis"].ToString();
                        string status = reader["stanje"].ToString();
                        task = new Zadatak { ID = id, WorkerID = workerId, Title = title, EstimatedTime = estimatedTime, Difficulty = difficulty, Description = description, Status = status };
                    }
                    return task;
                }
            }
        }

        public void RemoveTask(int taskId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                int id = 0;
                sqlConnection.Open();
                string command = "delete from dbo.Zadatak where zadatak_id=@taskId select Scope_Identity()";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlCommand.Parameters.AddWithValue("taskId", taskId);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void EditTask(Zadatak task)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                string command = "update dbo.Zadatak set radnik_id=@workerId,naslov=@title,procenjeno_vreme=@estimatedTime,tezina=@difficulty,opis=@description,stanje=@status where zadatak_id=@id";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", task.ID);
                sqlCommand.Parameters.AddWithValue("@workerId", task.WorkerID);
                sqlCommand.Parameters.AddWithValue("@title", task.Title);
                sqlCommand.Parameters.AddWithValue("@estimatedTime", task.EstimatedTime);
                sqlCommand.Parameters.AddWithValue("@difficulty", task.Difficulty);
                sqlCommand.Parameters.AddWithValue("@description", task.Description);
                sqlCommand.Parameters.AddWithValue("@status", task.Status);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public int AddEmployee(Employee employee)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                int id = 0;
                sqlConnection.Open();
                string command = "insert into dbo.Radnik(ime_i_prezime,radno_mesto) values(@nameAndSurname,@workplace) select scope_identity()";
                SqlCommand cmd = new SqlCommand(command, sqlConnection);
                cmd.Parameters.AddWithValue("@nameAndSurname", employee.NameAndSurname);
                cmd.Parameters.AddWithValue("@workplace", employee.Workplace);
                id = Convert.ToInt32(cmd.ExecuteScalar());
                return id;
            }
        }
    }
}