using EcsRx.Infrastructure.Dependencies;

namespace Game.Modules
{
  public class ComputedModule : IDependencyModule
  {
    public void Setup(IDependencyContainer container)
    {
      //container.Bind<IMovementDistanceComputed>(c =>
      //                                          {
      //                                            c.ToMethod(x =>
      //                                                         {
      //                                                           var observableGroup = x.ResolveObservableGroup(typeof(PlayerComponent), typeof(MovableComponent));

      //                                                           return new MovementDistanceComputed(observableGroup);
      //                                                         });
      //                                          });
    }
  }
}