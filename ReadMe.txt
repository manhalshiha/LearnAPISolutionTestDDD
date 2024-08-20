principles of DDD:
1- bounded context : architecting and designing the application around areas of applicability or bounded context 
2- Entity: check equality based on identifier
3- Value Object:check equality based on values itself
	Notes:	when come to ddd must don't think about persistence 
			in value object ,the immutability is very imporatant so its properties' values must don't change after initialize . so we must initializ in constructor and we must protect it from edit ( make its set private {get; privat set;} and make method to create new object which have new values but that means the old object didn't have changed)
			value object doesn't care about id and relationship
			structural equality: is when to objects have same properties , so recordes is very important thing because records implements stryctural equality right form to get-go , also records implement immutability ( if we change any its propeties doesn't affect on the old record); so record from .net 8 is appropriate instead of value object 
	important challenges:
			when we store value object in database we need to identifier to define primary key
			we can't implement many to many relationship with value objet 


4- Aggregate: must be entity , it is important concept of DDD, it must contains all properties and method , it make sure boundary of						consistency,every thing in it must be secure from change from other it must be availabe to change only over aggregate					itself, so we must encapsulation it so it must no anybody can do any changes on our domain , to do that we need to						business urles to assure that never a state is invalid , examples:(if we want to create new project we must to put some					condition like countOfMembers ) ( if we have project then we want to revalue it as iscompleted we must to create method					dose these steps: set date to project's end and make all employees as free then set that project as iscmoleted )
					important notice: aggregate in not recommended with simple operations like crud operation.
5- Aggregate Root : it is intry point to my aggreagate 
						Modeling aggregate by 3 principles to make sure master of aggregate:
						1-keep aggregate simple : aggregates should contain only domain object that are bound together by some common business rules .
						2-state change throgh aggregate root: must always business rules and business requierment are met, aggreagate root should be responsible of any action that is performed is compliant to the business rules ,business logic and business validation , it is very impontant point to never change any the state of aggregate route nodes except through the aggregate root itself.
						3-never nest aggregates : sometimes we need to action perform business rules or business login for tow aggregate, to solve this problem we must use domain service concept 
6- Domain Service: it has 3 characteristics :
							1- operatioin in a certain domain service relates to a domain concept , so operation in domain service is business rules
							2- domain service works only with elements of the domain (all items we pass to domain service must to be value object , entity or aggregate from our domain layer)
							3- operation is stateless so the service itself is not used to persist any state and doesn't hold any state, it just perform a business rule and return a result 
							to avoid mixed tow business logic or business logic with application logic we must to create service in our domain layer that is a business logic which perform operation for tow aggregates , then that service will register in DI container then inject that service in application logic with handler to perform opreation like calculate new reating for the players.
7- value object persistence:1- entity framework needs to default constructor for all our models and	base classes like valueobject,entity and								aggregate class.
							2- we must try to stick principles of DDD 100% unless we can't really go around DDD .
							3- entity framework neeي to setter of properties to mapped them into database , so we shouldn't delete them but make them private .
							4-biggest problem with value object is they don't have identitfier ,and entity framework needs identifier to persist things to the database, so to solve this problem we go to AppDbContext and follow these:
								1- in DDD , any DbSet must be aggregate or aggregate roots ( that save our boundaries consistency so we shouldn't change any data outside this aggregate ) , here we must create configuration for AppDbContext that inherits from IEntityTypeConfiguration<Custome> (customer is aggregate)
								2- with DDD you don't want to use or put data annotation any more ,and you don't want to use useless navigation properties or identifiers ,all that can be handled through fluent configuration in entity framework core .
								3- entity has nice feature that is OwnsOne for to one relationship and OwnsMany for to manyrelationship , OwnsMany helps entity framework to generate shadow identifiers proerty .
8- Domain Event:	- to solve this challenge (a state change in one aggregate has side efficts on other aggregate )domain service doesn't							solve that .
					- Domain event ( something happend and other parts of the application might need to react with that something .so there are two concepts :	1- domain events: designed for side effectes inside the consistency boundaries (bounded context)
															usually handled in memory (synchronous way)
										  2- integaration events:designed for side effectes that cross the consistency boundaries (bounded									context has effects on another bounded context )
															usually handled by messages brokers (asynchronous way)	)
							create domain event:	1- create base EventDomain in shared kernel , we inherit it for every aggregate needs to							perform change on another aggregate,  
														notice:foe everey domain events we want two pars(raise domain , handle doamin)
													2- raise domain we do it domain layer, in aggregate base we create list of DomainEvent.
													3- then we add to aggregate base RaiseEvent motheod to add new DomainEvent to the							previous list 
													4- raise event implemented in aggregate because every aggregate has responsibility about					its boundaries consistency , but handle event must be in application layer								because we need to use AppDbContext and other things aren't exist in domain layer .
													5- in handler i want to send notifiaction to all class that inheritance from DomainEvent
														we could that by by mediateR , so the EventDomainBase must by inheritance from							 INotification 