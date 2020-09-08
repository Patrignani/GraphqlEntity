using GraphQL.Types;
using GraphqlEntity.Core.Models;

namespace GraphqlEntity.Core.Types
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Name = "User";
            Field(x => x.Id);
            Field(x => x.Identification);

        }
    }
}
