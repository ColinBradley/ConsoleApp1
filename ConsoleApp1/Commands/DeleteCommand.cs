internal class DeleteCommand : ICommand
{
    public string Key { get; set; }
    public string Title { get; set; }

    public void Run()
    {
        throw new NotImplementedException();
    }
}