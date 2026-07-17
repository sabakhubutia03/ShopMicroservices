using MediatR;
using Product.Application.Interface;
using Product.Domain.Exceptions;

namespace Product.Application.Commands.Category.DeleteCategory;

public class DeleteCategoryCommandHendler : IRequestHandler<DeleteCategoryCommand, Unit>
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryCommandHendler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        
        var deleteCategory = await _categoryRepository.GetById(request.Id);
        if (deleteCategory == null)
        {
            throw new ApiException(
                $"Not found category ID - {request.Id}",
                "NotFound",
                404,
                "Not found category",
                "Not found category"
            );
        }
        await _categoryRepository.Delete(deleteCategory);
        
        return Unit.Value;
    }
}