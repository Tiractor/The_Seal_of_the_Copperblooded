namespace Core.Roleplay.Inventory
{

    [System.Serializable]
    public class SlotData
    {
        public Item item;
        public int amount;


        public void Add(int value) => amount += value;
        public void Remove(int value) => amount -= value;

        public SlotData(SlotData slotData)
        {
            item = slotData.item;
            amount = slotData.amount;
        }
        public SlotData()
        {
            item = null;
            amount = 0;
        }

    }
}