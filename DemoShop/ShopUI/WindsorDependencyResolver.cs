using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Castle.Windsor;

namespace ShopUI
{
	//public class WindsorDependencyResolver : IDependencyResolver
	//{
	//	private readonly IWindsorContainer _container;

	//	public WindsorDependencyResolver(IWindsorContainer container)
	//	{
	//		_container = container;
	//	}
	//	public IDependencyScope BeginScope()
	//	{
	//		throw new NotImplementedException();
	//	}

	//	//public object GetService(Type serviceType)
	//	//{
	//	// if (_container.Kernel.HasComponent(serviceType)
	//	//  return this._container.Resolve(serviceType);
	//	// else
	//	//  return null;
	//	//}

	//	public IEnumerable<object> GetServices(Type serviceType)
	//	{
	//		throw new NotImplementedException();
	//	}

	//	public void Dispose()
	//	{
	//		throw new NotImplementedException();
	//	}
	//}
}