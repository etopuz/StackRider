public class GameManager : Singleton<GameManager>
{
    public GameState state = GameState.Playing;
}

public enum GameState
{
    Idle,
    Finished,
    Failed,
    Playing
}
