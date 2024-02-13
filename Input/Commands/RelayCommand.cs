using System;
using Mario.Interfaces;

public class RelayCommand : ICommand
{
    // 'Action' is a delegate. It works like a function pointer but in C#,
    // This class allows us to turn a void methd, into an ICommand. This
    // drastically simolifies the problem of having a new command class that
    // turns a function into a command each time... This solves that data issue.
    private readonly Action _execute;

    public RelayCommand(Action execute)
    {
        _execute = execute;
    }

    public void Execute()
    {
        _execute();
    }
}