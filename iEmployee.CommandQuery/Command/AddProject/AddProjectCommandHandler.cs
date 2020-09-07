using iEmployee.Domain;
using iEmployee.Infrastructure.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iEmployee.CommandQuery.Command.AddProject
{
    public class AddProjectCommandHandler : ICommandHandler<AddProjectCommand, Project>
    {
        private readonly iEmployeeContext db;
        public AddProjectCommandHandler(iEmployeeContext db)
        {
            this.db = db;
        }
        public async Task<Project> Handle(AddProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project(request.Name);
            db.Projects.Add(project);
            await db.SaveChangesAsync();
            return project;
        }
    }
}
