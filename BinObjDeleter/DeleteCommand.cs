using System;
using System.IO;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;

namespace BinObjDeleter
{
    public enum DeleteCommands
    {
        DeleteCommand,
    }
    public class DeleteCommandHandler : CommandHandler
    {

        protected override void Run()
        {
            base.Run();
            var projects = IdeApp.Workspace.GetAllProjects();
            foreach (var project in projects)
            {
                var dir = project.ItemDirectory;
                if (dir != null)
                {
                    try
                    {
                        var binPath = dir + "/bin";
                        var objPath = dir + "/obj";
                        if (Directory.Exists(binPath))
                        {
                            Directory.Delete(binPath, true);
                        }
                        if (Directory.Exists(objPath))
                        {
                            Directory.Delete(objPath, true);
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
