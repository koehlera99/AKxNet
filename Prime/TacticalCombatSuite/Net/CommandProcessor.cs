namespace TCS.Net
{
    class CommandProcessor
    {
        public static void ProcessCommand(Command command)
        {
            switch(command.CommandName)
            {
                case "MOVE":
                    Move(command);
                    break;
                default:
                    break;
            }
        }

        public static void Attack()
        {

        }

        public static void Move(Command command)
        {
            //BroadcastCommandToClients(command);
        }
    }

    //class Command
    //{
    //    public static void Process(Command command)
    //    {

    //    }
    //}
}
