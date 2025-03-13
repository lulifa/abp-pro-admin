using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace RuiChen.AbpPro.Saas
{
    public class EditionDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        protected IGuidGenerator GuidGenerator { get; }
        protected IEditionRepository EditionRepository { get; }

        public EditionDataSeederContributor(
            IGuidGenerator guidGenerator,
            IEditionRepository editionRepository)
        {
            GuidGenerator = guidGenerator;
            EditionRepository = editionRepository;
        }

        public async virtual Task SeedAsync(DataSeedContext context)
        {
            await AddEditionIfNotExistsAsync("Free");
            await AddEditionIfNotExistsAsync("Standard");
            await AddEditionIfNotExistsAsync("Professional");
            await AddEditionIfNotExistsAsync("Enterprise");
        }

        protected async virtual Task AddEditionIfNotExistsAsync(string displayName)
        {
            if (await EditionRepository.FindByDisplayNameAsync(displayName) != null)
            {
                return;
            }

            await EditionRepository.InsertAsync(
                new Edition(
                    GuidGenerator.Create(),
                    displayName
                )
            );
        }


    }
}
