public abstract class Item
{
    public int code;
    public int price;
    public int honor;
    public int grade;
    public string name;
    public string image;
    public Recipe recipe;

    public Item(int code, int price, int honor, int grade,string name ,string image, Recipe recipe)
    {
        this.code = code;
        this.price = price;
        this.honor = honor;
        this.grade = grade;
        this.name = name;
        this.image = image;
        this.recipe = recipe;
    }
    public Item(int code,int price,string name ,string image)
    {
        this.code = code;
        this.price = price;
        this.name = name;
        this.image = image;
    }
    // 무기류, 방어구류, 포션 및 약초류
}
