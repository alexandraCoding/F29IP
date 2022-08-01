using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class ProductsTests : MonoBehaviour
{
    [SetUp]
    public void SetUp()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/ProductSite.unity");
    }



    [Test]
    public void FindProductByNameTest()
    {
        //Arrange


        Products products = new Products();
        products.ProductMembers = ProductFactory.GetProducts().ProductMembers;

        //Act
        var productfound = products.FindProductByProductName("GRID_Building");


        //Assert
        Assert.AreEqual("GRID_Building", productfound.productname);
    }
    [Test]
    public void FindProductByKeyTest()
    {
        //Arrange


        Products products = new Products();
        products.ProductMembers = ProductFactory.GetProducts().ProductMembers;

        //Act
        var index = products.FindProductByKey(1);
        var index2 = products.FindProductByKey(2);
        var index3 = products.FindProductByKey(3);
        var index4 = products.FindProductByKey(4);


        //Assert

        Assert.AreEqual(0, index);

        Assert.AreEqual(1, index2);
        Assert.AreEqual(2, index3);
        Assert.AreNotEqual(3, index4);
    }

    [Test]
    public void UpdateProductTest()
    {
        //Arrange


        Products products = new Products();
        products.ProductMembers = ProductFactory.GetProducts().ProductMembers;

        Product producttoreplace = new Product
        {
            IDCODE = 10021,
            productname = "GRID_Building",
            description = "Floor_2",
            category = "StorageAccount"
        };

        //Act
        //var index = people.FindPersonByKey(1);

        products.UpdateProduct(1, producttoreplace);


        //Assert

        Assert.AreEqual(producttoreplace.productname, products.ProductMembers[0].productname);

    }


    [Test]
    public void DeleteProductTest()
    {
        //Arrange


        Products products = new Products();
        products.ProductMembers = ProductFactory.GetProducts().ProductMembers;



        //Act
        //var index = people.FindPersonByKey(1);

        products.DeleteProduct(3);


        //Assert

        Assert.AreEqual(2, products.ProductMembers.Count);

    }

    [Test]
    public void InsertProductTest()
    {
        //Arrange
        Products products = new Products();
        products.ProductMembers = ProductFactory.GetProducts().ProductMembers;

        Product producttoadd = new Product
        {
            IDCODE = 10021,
            productname = "GRID_Building",
            description = "Floor_2",
            category = "StorageAccount"
        };

        //Act
        //var index = people.FindPersonByKey(1);

        products.InsertProduct(producttoadd);


        //Assert

        Assert.AreEqual(4, products.ProductMembers.Count);

    }


    [Test]
    public void GetNextKeyTest()
    {
        //Arrange


        Products products = new Products();
        products.ProductMembers = ProductFactory.GetProducts().ProductMembers;


        int returnedkey = products.GetNextKey();

        //Assert

        Assert.AreEqual(3, products.ProductMembers.Count);
        Assert.AreEqual(4, returnedkey);


    }
}
