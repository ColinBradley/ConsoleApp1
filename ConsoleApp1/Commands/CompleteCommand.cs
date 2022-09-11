using System.Reflection.Metadata.Ecma335;

internal class CompleteCommand : ICommand
{
    private List<TodoItem> _todoItems;

    public CompleteCommand(List<TodoItem> todoItems)
    {
        _todoItems = todoItems;
    }

    public string Key { get; } = "C";

    public string Title { get; set; } = "Complete item";

    public void Run()
    {
        Console.WriteLine("Which item shall I complete?");

        while(true)
        {
            var userChoice = Console.ReadLine();
        
            var isANumber = int.TryParse(userChoice, out var userChoiceParsed);

            if (!isANumber || userChoiceParsed < 0 || userChoiceParsed >= _todoItems.Count)
            {
                Console.WriteLine("Bad form!");
                continue;
            }

            var pickedItem = _todoItems[userChoiceParsed - 1];

            pickedItem.IsComplete = true;
            break;
        }
    }
}
