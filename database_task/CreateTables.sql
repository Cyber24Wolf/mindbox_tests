CREATE TABLE Category(
	category_name varchar(64) NOT NULL,

	item_id int IDENTITY(1, 1) NOT NULL,
	PRIMARY KEY(item_id)
);

CREATE TABLE Product(
	product_name varchar(64) NOT NULL,
	product_categories varchar(128) NOT NULL,
	
	item_id int IDENTITY(1, 1) NOT NULL,
	PRIMARY KEY(item_id)
);