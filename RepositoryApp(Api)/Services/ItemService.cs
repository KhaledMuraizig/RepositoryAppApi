using AutoMapper;
using RepositoryApp_Api_.Data;
using RepositoryApp_Api_.DTOs;

namespace RepositoryApp_Api_.Services
{
    public class ItemService : IItemService
    {
        Context context;
        IMapper mapper;

        public ItemService(Context _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public void Add(ItemDTO itemDTO)
        {
            Item item = mapper.Map<Item>(itemDTO);
            context.Items.Add(item);
            context.SaveChanges();
        }

        public List<ItemDTO> LoadAll()
        {
            List<Item> items = context.Items.ToList();
            List<ItemDTO> itemDTOs = mapper.Map<List<ItemDTO>>(items);
            return itemDTOs;
        }

        public void Delete(int Id)
        {
            Item item = context.Items.Find(Id);
            context.Items.Remove(item);
            context.SaveChanges();
        }

        public ItemDTO Load(int Id)
        {
            Item item = context.Items.Find(Id);
            ItemDTO itemDTO = mapper.Map<ItemDTO>(item);
            return itemDTO;
        }

        public void Update(ItemDTO itemDTO)
        {
            Item item = mapper.Map<Item>(itemDTO);
            context.Items.Attach(item);
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
