/*
 * My Lovely Todo app!
 * 
 * 1. Take out the trash
 * 2. Take over the world
 * 
 * Actions:
 * A. Add Item
 * D. Delete item
 * C. Complete item
 * 
 */

using System.ComponentModel.Design;
using System.Data;
using System.Security.AccessControl;

var todoItems = new List<TodoItem>();

var myFirstItem = new TodoItem();
myFirstItem.Description = "Take out the trash";

todoItems.Add(myFirstItem);

todoItems.Add(new TodoItem()
{
    Description = "Take over the world",
    IsComplete = true
});

var isRunning = true;
while (isRunning)
{
    Console.WriteLine("My Lovely Todo App \n");

    var index = 1;
    foreach (var item in todoItems)
    {
        Console.WriteLine($"{index}. {item.Description}\t: {(item.IsComplete ? "Complete" : "Incomplete")}");

        index++;
    }

    Console.WriteLine("\nActions:\n");

    var commands = new List<ICommand>();
    commands.Add(new AddCommand() { Key = "A", Title = "Add new item" });
    commands.Add(new DeleteCommand() { Key = "D", Title = "Delete item" });
    commands.Add(new CompleteCommand(todoItems));

    foreach (var command in commands)
    {
        Console.WriteLine($"{command.Key}. {command.Title}");
    }

    var userResponse = Console.ReadLine();

    foreach (var command in commands)
    {
        if (string.Equals(userResponse, command.Key, StringComparison.OrdinalIgnoreCase))
        {
            command.Run();
        }
    }

    Console.Clear();
}
