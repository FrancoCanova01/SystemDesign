using System;

namespace FactoryMethodDesignPatternInCSharp  
{  


     //Este es el codigo del Cliente

    public class ClientApplication  
    {  
        static void Main()  
        {  
            CardFactory factory = null;  
            //string car = Console.ReadLine();  
            string car = "moneyback";

            Console.WriteLine("Tu seleccion es: {0}", car);

            //Notar como se asigna a factory del tipo "CardFactory" los tipos 
            //que implementan dicha clase abstracta (ie: MoneyBackFactory, TitaniumFactory,
            //PlatinumFactory). Permite abstraerte delegate tipo concreto que pedirá el 
            //cliente y responder con el tipo correcto dependiendo de su 
            //input. De agregar una nueva entonces se deberái crear el "Producto"
            //y por el otro crear otra "ConcreteFactory" para dicho producto además de
            //actualizar el switch statement de abajo.


            switch (car.ToLower())  
            {  
                case "moneyback":  
                    factory = new MoneyBackFactory(50000, 0);  
                    break;  
                case "titanium":  
                    factory = new TitaniumFactory(100000, 500);  
                    break;  
                case "platinum":  
                    factory = new PlatinumFactory(500000, 1000);  
                    break;
                default:  
                    break;  
            }
  
            //Sin importar que se eligió, el metodo GetCreditCard() está en la clase
            //abstracta CreditCard e implementada por todas las Clases Concretas
            //que heredan de ella.
            
            
            CreditCard creditCard = factory.GetCreditCard();  
            Console.WriteLine("\nYour card details are below : \n");  
            Console.WriteLine("Card Type: {0}\nCredit Limit: {1}\nAnnual Charge: {2}",  
                creditCard.CardType, creditCard.CreditLimit, creditCard.AnnualCharge);  
            Console.ReadLine();  
        }  
    }  








    /// <summary>  
    /// The 'Product' Abstract Class  
    /// </summary>  
    abstract class CreditCard  
    {  
        public abstract string CardType { get; }  
        public abstract int CreditLimit { get; set; }  
        public abstract int AnnualCharge { get; set; }  
    }

    /// <summary>  
    /// A 'ConcreteProduct' class  (Hereda de 'Product Abstract Class')
    /// </summary>  
    class MoneyBackCreditCard : CreditCard  
    {  
        //Field
        private readonly string _cardType;  
        //Field
        private int _creditLimit;  
        //Field
        private int _annualCharge;  
  
        //Method
        public MoneyBackCreditCard(int creditLimit, int annualCharge)  
        {  
            _cardType = "MoneyBack";  
            _creditLimit = creditLimit;  
            _annualCharge = annualCharge;  
        }  

        //Property
        public override string CardType  
        {  
            get { return _cardType; }  
        }  
  
        //Property
        public override int CreditLimit  
        {  
            get { return _creditLimit; }  
            set { _creditLimit = value; }  
        }  
  
        //Property
        public override int AnnualCharge  
        {  
            get { return _annualCharge; }  
            set { _annualCharge = value; }  
        }  
    }



    /// <summary>  
    /// A 'ConcreteProduct' class  (Hereda de 'Product Abstract Class')
    /// </summary>  
    class TitaniumCreditCard : CreditCard  
    {  
        //Field
        private readonly string _cardType; 
        //Field 
        private int _creditLimit;  
        //Field
        private int _annualCharge;  

        //Method
        public TitaniumCreditCard(int creditLimit, int annualCharge)  
        {  
            _cardType = "Titanium";  
            _creditLimit = creditLimit;  
            _annualCharge = annualCharge;  
        }  
    
        //Property
        public override string CardType  
        {  
            get { return _cardType; }  
        }  

        //Property
        public override int CreditLimit  
        {  
            get { return _creditLimit; }  
            set { _creditLimit = value; }  
        }  
  
        //Property
        public override int AnnualCharge  
        {  
            get { return _annualCharge; }  
            set { _annualCharge = value; }  
        }      
    }  


    /// <summary>  
    /// A 'ConcreteProduct' class  (Hereda de 'Product Abstract Class')
    /// </summary>  
    class PlatinumCreditCard : CreditCard  
    {  
        //Field
        private readonly string _cardType;  
        //Field
        private int _creditLimit;  
        //Field
        private int _annualCharge;  
  
        //Method
        public PlatinumCreditCard(int creditLimit, int annualCharge)  
        {  
            _cardType = "Platinum";  
            _creditLimit = creditLimit;  
            _annualCharge = annualCharge;  
        }  
  
        //Property
        public override string CardType  
        {  
            get { return _cardType; }  
        }  
  
        //Property
        public override int CreditLimit  
        {  
            get { return _creditLimit; }  
            set { _creditLimit = value; }  
        }  

        //Property
        public override int AnnualCharge  
        {  
            get { return _annualCharge; }  
            set { _annualCharge = value; }  
        }  
    }  




    //Hasta acá se crearon distintos "Productos"
    //Ahora se arranca la parte de los "Creators"





    /// <summary>  
    /// The 'Creator' Abstract Class  
    /// </summary>  
    abstract class CardFactory  
    {  
        public abstract CreditCard GetCreditCard();  
    } 


    /// <summary>  
    /// A 'ConcreteCreator' class  (Hereda de la 'Creator' Abstract Class)
    /// </summary>  
    class MoneyBackFactory : CardFactory  
    {  
        private int _creditLimit;  
        private int _annualCharge;  
  
        public MoneyBackFactory(int creditLimit, int annualCharge)  
        {  
            _creditLimit = creditLimit;  
            _annualCharge = annualCharge;  
        }  
  
        public override CreditCard GetCreditCard()  
        {  
            return new MoneyBackCreditCard(_creditLimit, _annualCharge);  
        }  
    }  

    /// <summary>  
    /// A 'ConcreteCreator' class  (Hereda de la 'Creator' Abstract Class)
    /// </summary>  
    class TitaniumFactory: CardFactory      
    {      
        private int _creditLimit;      
        private int _annualCharge;      
      
        public TitaniumFactory(int creditLimit, int annualCharge)      
        {      
            _creditLimit = creditLimit;      
            _annualCharge = annualCharge;      
        }      
      
        public override CreditCard GetCreditCard()      
        {      
            return new TitaniumCreditCard(_creditLimit, _annualCharge);      
        }      
    }      



    /// <summary>  
    /// A 'ConcreteCreator' class  (Hereda de la 'Creator' Abstract Class)
    /// </summary>  
    class PlatinumFactory: CardFactory      
    {      
        private int _creditLimit;      
        private int _annualCharge;      
      
        public PlatinumFactory(int creditLimit, int annualCharge)      
        {      
            _creditLimit = creditLimit;      
            _annualCharge = annualCharge;      
        }      
      
        public override CreditCard GetCreditCard()      
        {      
            return new PlatinumCreditCard(_creditLimit, _annualCharge);      
        }      
    }       
}  

