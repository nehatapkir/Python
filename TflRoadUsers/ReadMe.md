# Read Me



# Building the code

The code has been built using the .Net Framework 4.8. Ensure the framework has been installed on your machine prior to building it.
To build the project **TflRoadUsers** use the Nuget package manager to install **Microsoft.AspNet.WebApi.Client**

For building the test project - **TflRoadUsersTests** ensure that the Moq package is installed via the Nuget package manager.
The Moq should install the following dependencies :

 - Castle.Core 
 - Microsoft.AspNet.WebApi.Client
 -  MSTest.TestAdapter
   - MSTest.TestFramework 
 -   Newtonsoft.Json
 -  System.Runtime.CompilerServices.Unsafe
 -  System.Threading.Tasks.Extensions

## Running the output

The project has been created using the console application solution type.
Enter the **app_id** and **app_key** values in the **App.config** =>**appsettings** for the project **TflRoadUsers**.
Once the project has been built successfully, run the project by pressing **F5** and follow the below steps :

1) The application will ask you to enter a road id. 
2) On entering the road id, the road status and road status description will be displayed.
3) In case an invalid id is entered, an appropriate error message is displayed.

## Running the unit tests

The unit tests use the TDD approach.
Enter the **app_id** and **app_key** values in the **App.config** =>**appsettings** for the project **TflRoadUsersTests**.
Ensure that the build configurations and the Test platform match by checking the **Test**=>**Test settings** => **Default process architecture**.
Using the **Test Explorer** (Test=>Windows=>Test Explorer) run all or selected tests.


# Other comments

Note that for entering another road id you will need to re-run the application.