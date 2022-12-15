using Microsoft.Data.SqlClient;

using Adonet;
using System.Drawing;

string connectionString = @"Server=DESKTOP-SOO30PD\SQLEXPRESS;Database=BB101;Trusted_Connection=True";



GetAllEmployees();

List<Employee> GetAllEmployees()
{
    List<Employee> employees = new List<Employee>();
    using (SqlConnection connection = new(connectionString))
    {
        connection.Open();

        string query = "SELECT * FROM Empoloyee";

        SqlCommand command = new(query, connection);
        SqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Employee employee = new()
                {
                    ID = (int)reader["ID"],
                    Name = (string)reader["Name"],
                    Surname = (string)reader["Surname"],
                    Salary = (decimal)reader["Salary"]

                };
                employees.Add(employee);
                
            }
        }
        return employees;
    }
}

void GetEmployeeById(int id)
{

    using (SqlConnection connection = new(connectionString))
    {
        connection.Open();

        string query = $"SELECT * FROM Employee WHERE Empolyee='@id'";
       

        SqlCommand command = new(query, connection);
        command.Parameters.AddWithValue("@id", id);
        SqlDataReader reader = command.ExecuteReader();
        if(reader.HasRows)
        {

        while(reader.Read())
        {
            Employee employee = new()
            {
                ID = (int)reader["ID"],
                Name = (string)reader["Name"],
                Surname = (string)reader["Surname"],
                Salary = (decimal)reader["Salary"]

            };
        }
        Console.WriteLine(reader["ID"]);
        }
        else
        {
            throw new NotFoundExpection("Not found");
        }

    }
}

void CreateEmployee(Employee employee)
{
    using (SqlConnection connection = new(connectionString))
    {
        connection.Open();

        string query = "INSERT INTO Groups VALUES ('@name','@Surname','@Salary')";

        SqlCommand command = new(query, connection);
        command.Parameters.AddWithValue("@name", employee.Name);
        command.Parameters.AddWithValue("@Surname", employee.Surname);
        command.Parameters.AddWithValue("@Salary", employee.Salary);
        int result = command.ExecuteNonQuery(); 

        Console.WriteLine($"{result} rows affected");
    }
}
List<Employee> SearchSizesByName(string name)
{
    List<Employee> employees = new List<Employee>();
    using (SqlConnection connection = new(connectionString))
    {
        connection.Open();

        string query = $"SELECT * FROM Employee WHERE Employee LIKE '%' + @name + '%'";
        

        SqlCommand command = new(query, connection);
        command.Parameters.AddWithValue("@name", name);
        SqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Employee employee = new()
                {
                    ID = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Surname = (string)reader["Surname"],
                    Salary = (decimal)reader["Salary"]

                };
                employees.Add(employee);
                
            }
        }
        return employees;
    }
}