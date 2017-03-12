# Parking Lot Design
check the book *Cracking The Coding Interview* for more details.

#Analysis
* think about data model.
	* **Parking spot** - it has id, size, location etc. information.
	* **Parking lots**
		* Properties
			* it has a collection of parking spots; it can add/remove and even update the parking spot.
			* internal data structure to maintain a sport-car mapping.
		* Methods.
			* `ParkingSport RequestSport(Car car);`
			* `void LeaveSpot(Car car);`
	* **Car** - it has information like id and size.

**Update**

* at this point I'm not sure how to proceed without more requirements. 
* Does that mean I'm unclear about the design when requirements are vague? 
* Probably I should list a few highly possible scenarios and then make a flexible design?
* In addition to data model, what else should I consider in design?

**Analysis Continued**

* To support multiple parking spot size, spot object has a property size. Is it the right design? Probably not. 
	* Parking lot object doesn't need to know the size detail and what spot can fit. 
	* Maybe just ask the spot object if a car can fit. It means spot has a method like `bool CanFit(Car car);`. 
	* It also means `Car` needs to expose a size property. Even better, we can implement an IObject interface which has the size information so spot can accept any kind of objects (like car, motocycle, trailer). 
	* Remeber single response principle (keep parking lot simple), and also flexible using the interface (in this case, we support any object with size).
* Spot can have a IsTaken property so parking spot can find spare spots.
* Should Spot be an interface? Maybe. I don't see the value unless there're many different types of space. (I didn't mean size difference in this case, because CanFit method encapsulates it very well).

**Update**

* The book has slightly different requirements so the code is more complicated but the idea is the same.
* We should always start with requirements and discuss with people before starting the design.
* Object Model is the right way.
* Think of these objects as robot so we can send command to them when call the methods. In this case, a car can go to or leave the parking spot.

**Update after reading the book**
There're a few steps to tackle these questions,

1. handle ambiguilty - questions are vague so we need to make assumptions and ask clarification questions.
	* Customers - who are going to use?
	* Scenario - how are they going to use?
	* Dependens on the answers, we may have 6 common follow-up questions `what, why, who, how, when, where`.
	* It gives a good example `make a coffee machine`. It could be used in office like Microsoft that makes thousonds of coffice and many users every day, or in home that a few people use daily. The problem size could be significantly different.
2. Define the core objects. It is the data model part.
3. Analyze Relationships,
	* OOP has inheritence, composition etc. relations.
		* one object is a member of another object?
		* inheritance
		* many to many or one to many
	* In OOP we can use,
		* interface
		* base/subclass
		* property
		* we can even think of some design patterns like factory, adapter.
