# Checkout Kata

***An [explanation of the solution](#solution) in this repository is provided below.***

Implement a solution for a checkout kata that follows the requirements below.

1.  **_Given_** I have selected to add an item to the basket **_Then_** the item should be added to the basket

2.  **_Given_** items have been added to the basket **_Then_** the total cost of the basket should be calculated

3.  **_Given_** I have added a multiple of 3 lots of item 'B' to the basket **_Then_** a promotion of '3 for 40' should be applied to every multiple of 3 (see: Grid 1).

4.  **_Given_** I have added a multiple of 2 lots of item 'D' to the basket **_Then_** a promotion of '25% off' should be applied to every multiple of 2 (see: Grid 1).

### _Grid 1:_

| Item SKU | Unit Price | Promotions                             |
| -------- | ---------- | -------------------------------------- |
| A        | 10         |                                        |
| B        | 15         | 3 for 40                               |
| C        | 40         |                                        |
| D        | 55         | 25% off for every 2 purchased together |

Items are priced individually. In addition, there are promotions which can affect the total price of the basket, for example, when 3 lots of item 'D' are added to the basket then a 25% deduction is applied to the total cost of 2 of those items. The pricing changes frequently, so pricing should be independent of the checkout.

## Guidance

- Please commit Kata to your own public GitHub repository

- Commit frequently to show approach taken

- Complete Kata in C#

- Demonstrate your understanding of good naming, coding, testing, and design practices

- We recommend you spend between 1-2 hours on this solution - Kata does not have to be complete

## Solution

The proposed solution in this repository leverages the Strategy Pattern, with a given strategy for each kind of Promotion specified in the kata description. By following this pattern, it allows for the context, in this case the `Basket` class, to maintain the Single Responsibility Principle, and concern itself only with the intended functionality of the basket. The basket therefore does not concern itself with the implementation details of current (or future) promotional strategies, and future strategies can be added to the solution independently of one another without modifying the basket, helping to make the system open to extension and closed to modification (adhering to the Open Closed Principle).

In addition, by using the `PromoId` property on the `IPromotion` interface, the strategy pattern allows the basket to dynamically select the appropriate strategy at runtime, dependent wholly upon which promotional items (if any) that are put into the basket. Dynamic selection is made possible by use of another pattern, the Factory Pattern, in the `AvailablePromotionsFactory` class. This class exposes a `Dictionary` of available strategies and allows for the creation of a new instance of the appropriate strategy depending upon the current `PromoId` supplied.

*'Thin'* interfaces were favoured, examples in the code being `IItem` and `IPromotional`, which allowed for clients to only implement the interfaces that they required and not forced to implement members that weren't. This design choice was informed by the Interface Segregation Principle, and allowed for composition over unnecessary inheritance, an example of which is shown in the `PromotionalItem` class, where the aforementioned interfaces were composed together to enforce the required implementation of `PromoId`.

Frequent commits were made and a good commit history was maintained to evidence the TDD approach taken to complete this kata. NUnit was my testing framework of choice, and the **NUnit Constraint Model of Assertions** was employed to both ensure tests were 'human readable' (which might be beneficial in a real life scenario in the case of tests being reviewed by a non-technical stakeholder), and also because this is the more up-to-date and currently maintained model of assertions provided by NUnit.