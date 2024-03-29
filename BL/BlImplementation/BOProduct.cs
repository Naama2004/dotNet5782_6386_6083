﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using BLApi;
using BO;
using DO;
//using DalApi;
namespace BlImplementation;

public class BOProduct : IProduct
{
   static DalApi.IDal? dal = DalApi.Factory.Get();
    #region get all products
    public IEnumerable<BO.ProductForList> GetProducts()
    {

            IEnumerable<DO.Product> tempList = dal!.Product.GetAll();
        //List<DO.Product> tempList = dal.Product.GetAll().ToList();//get all of the products from DO into a temp list 
        return (from P in tempList//return as an IEnumerable of BO Products 
                                  //  let productFromDO = p.Product.GET(P.ID)
                select new BO.ProductForList()
                {
                    ProductId = P.ID,
                    Print = P.Print,
                    price = P.Price,
                    Category = (BO.Enums.Category)P.Category!,
                    InStock = P.InStock,
                }).ToList();

    }
    #endregion

    #region get product info for manager
    public BO.Product ProductInfoManeger(int id)
    {
        try
        {
            if (id > 0)
            {

                DO.Product productDO = dal!.Product.GET(id);//get that specific DO entity by its ID
                                                         //is the ID is valid , but is not found in DO GET will throw an Exeption Therefor:
                                                         //catch()
                BO.Product productBO = new BO.Product();//bulid a BO entity 
                productBO.ID = productDO.ID;//set the wanted values into the BO entity 
                productBO.Print = productDO.Print;
                productBO.Price = productDO.Price;
                productBO.category = (BO.Enums.Category)productDO.Category;
                productBO.instock = productDO.InStock;
                return productBO;//return the BO entity 
            }
            throw new InValidIdException("the id was invalid");
        }
        catch (DO.UnfounfException x)
        {
            throw new NotFoundException("id is not found", x);
        }
        //the ID isnt valid and for sure isnt in DO
    }
    #endregion

    #region get product info client
    public BO.ProductItem ProductInfoClient(int id, BO.cart c)
    {
        try
        {
            if (id > 0)
            {
                DO.Product productDO = dal.Product.GET(id);//if the id isnt found in the DO Get will throw an Exeption 
                BO.ProductItem temp = new BO.ProductItem();
                temp.Price = productDO.Price ?? 0;//if for some reason the Price is null put a Zero in it 

                //maybe we should throw an Exeption ? because we dont want to allow the costumer to see price 0 

                temp.Print = productDO.Print;
                temp.ProductId = productDO.ID;
                if (productDO.InStock != 0)//the costumer only need to see if the item is avileable not how many are there 
                {
                    temp.InStock = true;
                }
                else temp.InStock = false;
                temp.category = (BO.Enums.Category)productDO.Category;//i dont think we're converting the category coreccty 


                temp.AmountInCart =(int)c.items.FirstOrDefault(x => x.ProductId == productDO.ID).amount;
                //find in the cart the orderitem that matches the product id and put the amount in the BO entity 
                return temp;
            }
            else//the ID isnt valid 
                throw new InValidIdException("the id was invalid");
        }
        catch (NotFoundException x)
        {
            throw new NotFoundException("id is not found", x);
        }
    }
    #endregion

    #region add product as a manager
    public void AddProductmaneger(BO.Product P)
    {
        try
        {
            if (P.ID > 0 && P.Print != " " && P.Price > 0 && P.instock >= 0)
            {
                DO.Product DOp = new DO.Product();//creates a DO entity to add to the Data 

                DOp.ID = P.ID;
                DOp.Print = P.Print;
                DOp.Price = P.Price;
                DOp.InStock = P.instock;
                DOp.Category = (DO.Enums.Category)P.category;



                dal?.Product.ADD(DOp);//ADD might throw an Exeption in case were trying to add a product that already exist 

            }
        }
        catch (DO.ExistIdException x)
        {
            throw new IdExistException("the id already exists", x);
        }
        //if one of the details isnt valid throw an Exeption 
    }
    #endregion

    #region remove product as a manager
    public void RemoveProductmaneger(int id)
    {
        //checks if the product is in one of the orders 
        //i dont know how to do it 


        //throw an Exeption if its in the orders 
        try
        {
            dal!.Product.DELETE(id);//tries to delete the product from DO if the object does not exist DELETE will throw an Exeption 
        }
        catch(DO.UnfounfException ex)
        {
            throw new NotFoundException("id was not found", ex);
            //catch the non-Existing Exeption and throw it again 

        }
    }
    #endregion

    #region update info manager
    public void UpdateProductmaneger(BO.Product P)
    {
        if (P.ID > 0 && P.Print != " " && P.Price > 0 && P.instock >= 0)
        {
            DO.Product DOp = new DO.Product();//creates a DO entity with the updated info
            DOp.ID = P.ID;
            DOp.Print = P.Print;
            DOp.Price = P.Price;
            DOp.InStock = P.instock;
            DOp.Category = (DO.Enums.Category)P.category;
            try
            {
                dal.Product.UPDATE(DOp);//try to update the DO if the product doest not exist the call for DELETE in UPDATE will throw an Exeption 
            }
            catch (DO.UnfounfException x)
            {//catch the Exeption and throw it 
                throw new NotFoundException("id is not found", x);
            }
        }
        else
        {
            throw new InValidIdException("one or more of the details is not valied");
        }  
    }
    #endregion

    #region get all products by a condition
    public IEnumerable<BO.ProductForList>  GetProductsByCondition(Func<ProductForList, bool> func, IEnumerable<BO.ProductForList> productForLists)
        => productForLists.Where(func);

    #endregion


    public BO.Product createProductByValues(int id, string name,int instock,double price ,string cat)
    {
        BO.Product product = new BO.Product();
        product.ID = id;
        product.Print = name;
        product.instock=instock;
        
        product.Price = price;
        switch (cat)
        {
            //Tshirt, Sweatshirt, Sweatpant, BucketHat, Socks
            case "Tshirt":
                product.category = BO.Enums.Category.Tshirt;
                break;
            case "Sweatshirt":
                product.category = BO.Enums.Category.Sweatshirt;
                break;
            case "Sweatpant":
                product.category = BO.Enums.Category.Sweatpant;
                break;
            case "BucketHat":
                product.category = BO.Enums.Category.BucketHat;
                break;
             case "Socks":
                product.category = BO.Enums.Category.Socks;
                break;
    }
        return product;
    }

}


