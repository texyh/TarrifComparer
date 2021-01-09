# TarrifComparer
This is a simple solution that compares two electricity tarrif products(packages).  
The solution contains two projects:  
`TarrifComparer.Core` - This contains all the objects/models and also the logic for calculating electricity consumption costs. The `TarrifProductComparer` Class houses the products and exposes the `Compare` method which accepts the electricity consumed as parameter, the method aggregate the cosumptions cost from the two tarrif products and returns a comparism result which is list of `Tarrif Name` and the `Annual Cost` of the each product. I applied SOLID principle swhile developing this solution making easy to extend, for example adding a new product is as easy and creating a new class and implementing the `ITarrifProduct` interface.

`TarrifComparer.Tests` - This is an Xunit test project which houses all the unit tests for the `TarrifProductComparer` and the two tarrif products.