using ModestTree;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public GameObject gameManager;
    public override void InstallBindings()
    {
        Assert.IsNotEqual(gameManager, null);  
        Container.Bind<GameManager>().FromNewComponentOn(gameManager).AsSingle().NonLazy();
    }
}