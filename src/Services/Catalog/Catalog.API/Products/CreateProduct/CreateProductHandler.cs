
using Microsoft.IdentityModel.Tokens.Experimental;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name,List<string> Category, string Description,string ImageFile,decimal Price): ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator() 
        { 
         RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
         RuleFor(x => x.Category).NotEmpty().WithMessage("Name is required");
         RuleFor(x => x.Description).NotEmpty().WithMessage("Name is required");
         RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Name is required");
         RuleFor(x => x.Price).GreaterThan(0).WithMessage("Name should be greater than (0)");
        }
    }
    internal class CreateProductCommandHandler
        (IDocumentSession session)
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {

           
            // Create Product entity from command object
            var product = new Product()
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,
            };
            // Database Opertions
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            // return result
            return new CreateProductResult(product.Id);
        }
    }
}
