using System.Reflection;
using log4net;
using log4net.Config;

public class GlobalLoggerFixture
{
    public GlobalLoggerFixture()
    { 
        var repository = LogManager.GetRepository(Assembly.GetExecutingAssembly());

        XmlConfigurator.ConfigureAndWatch(repository, new FileInfo("log4net.config"));
        LogManager.GetLogger(typeof(GlobalLoggerFixture)).Info("GlobalLoggerFixture initialized");
    }
}