using System.Collections;
using System.Collections.Generic;

public interface IPlayerStats
{
    //remember an interface is a blueprint...what should all players have
    //private string name;

    public string PlayerName { get; }

    public int Score { get; }

}
