using kiteAutoInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace KiteAutoInjection.Test
{
    public class DependencyTest
    {
        [Fact]
        public void TransientDependencyShouldDifferent()
        {

            var s = new ServiceCollection();
            s.AutoInjection();

            var sp = s.BuildServiceProvider();
            var scope1 = sp.CreateScope();

            

            var a = scope1.ServiceProvider.GetRequiredService<TransientDependencyTestClass>();
            var b = scope1.ServiceProvider.GetRequiredService<TransientDependencyTestClass>();

            Assert.NotEqual(a.Id, b.Id);

            scope1.Dispose();
            
        }

        [Fact]
        public void ScopedDependencyShouldDifferentWhenDifferentScope()
        {

            var s = new ServiceCollection();
            s.AutoInjection();

            var sp = s.BuildServiceProvider();
            var scope1 = sp.CreateScope();

            var a = scope1.ServiceProvider.GetRequiredService<ScopedDependencyTsetClass>();
            var b = scope1.ServiceProvider.GetRequiredService<ScopedDependencyTsetClass>();

            Assert.Equal(a.Id, b.Id);

            var scope2 = sp.CreateScope();

            var c = scope2.ServiceProvider.GetRequiredService<ScopedDependencyTsetClass>();

            Assert.NotEqual(a.Id, c.Id);
            Assert.NotEqual(b.Id, c.Id);

            scope1.Dispose();
            scope2.Dispose();

        }


        [Fact]
        public void SingletonDependencyShouldSame()
        {

            var s = new ServiceCollection();
            s.AutoInjection();

            var sp = s.BuildServiceProvider();
            var scope1 = sp.CreateScope();

            var a = scope1.ServiceProvider.GetRequiredService<SingletonDependencyTsetClass>();
            var b = scope1.ServiceProvider.GetRequiredService<SingletonDependencyTsetClass>();

            Assert.Equal(a.Id, b.Id);

            var scope2 = sp.CreateScope();

            var c = scope2.ServiceProvider.GetRequiredService<SingletonDependencyTsetClass>();

            Assert.Equal(a.Id, c.Id);
            Assert.Equal(b.Id, c.Id);

            scope1.Dispose();
            scope2.Dispose();

        }


    }



}