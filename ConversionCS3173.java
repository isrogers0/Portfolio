import java.io.File;
import java.io.PrintWriter;
import java.util.Scanner;//equivalent to cin in c++
import java.util.Base64.Decoder;
public class ConversionCS3173
{
    public static void main(String [] args)
    {
        Scanner sc = new Scanner(System.in);

        try 
        {
            System.out.println("Please enter a decimal ");
            int decimal = sc.nextInt();

            System.out.println(Integer.toBinaryString(decimal) + " is the binary conversion of " + decimal);

            System.out.println("Please enter a binary number ");
            int binary = Integer.parseInt(sc.nextLine());

            String hexa = Integer.toHexString(binary);

            System.out.println(hexa + " is the HexaDecimal conversion of " + binary);

            sc.close();

        }
        catch(Exception e)
        {
            System.out.println(e.getMessage());
        }
    }
}