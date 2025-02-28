namespace Taller.CodeChallenge.Domain.AggregateModels.Request
{
    public class UserModel
    {
        public string IdUser { get; set; }
        public string UserName { get; set; }
    }

    public class UserModelToAdd
    {        
        public string UserName { get; set; }
    }
}
