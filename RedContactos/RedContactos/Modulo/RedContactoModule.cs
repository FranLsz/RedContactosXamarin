using System;
using Autofac;
using RedContactos.Service;
using RedContactos.View;
using RedContactos.ViewModel;
using Xamarin.Forms;

namespace RedContactos.Modulo
{
    public class RedContactoModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServicioDatos>().
                As<IServicioDatos>().
                SingleInstance();
            builder.Register<INavigation>(ctx => App.Current.MainPage.Navigation).SingleInstance();

            builder.RegisterType<Login>();
            builder.RegisterType<Registro>();
            builder.RegisterType<Home>();
            builder.RegisterType<ListadoUsuarios>();
            builder.RegisterType<LoginViewModel>();
            builder.RegisterType<RegistroViewModel>();
            builder.RegisterType<HomeViewModel>();
            builder.RegisterType<UsuariosViewModel>();

            // action es un delegado, es un objeto que se le pasa para operar sobre otro objeto
            // func es una funcion


            /*se registra la pagina
            Constuimos un objeto de forma manual
            decimos la instancia de que queremos registrar
            registirstramos una instancia en concreto, en vez de un tipo
            hacemos esto para saber que pagina se esta ejecutando
                

            */
            builder.RegisterInstance<Func<Page>>(() =>
            {
                // accedemos al mainpage y pedimos la masterdetaulpage
                var masterP = App.Current.MainPage as MasterDetailPage;
                // una vez tenemos el master, objetemos el page, si es nulo, obtenemos el masterdetail entero
                var page = masterP != null ? masterP.Detail : App.Current.MainPage;
                // lo mismo
                var navigation = page as IPageContainer<Page>;
                return navigation != null ? navigation.CurrentPage : page;
            });
        }
    }
}