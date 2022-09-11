
internal interface ICommand
{
    public string Key { get; }

    public string Title { get; }

    public void Run();
}