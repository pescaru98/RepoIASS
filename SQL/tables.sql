CREATE TABLE users(
user_id int NOT NULL auto_increment,
username varchar(100) unique not null,
password varchar(100) not null,
role varchar(50) not null,
name varchar(50) not null,
surname varchar(50) not null,
email varchar(50) unique not null,
primary key(user_id)
);

CREATE TABLE product(
product_id int NOT NULL auto_increment,
name varchar(50) not null,
price_per_unit int not null,
picture blob not null,
units int not null,
tag varchar(50) DEFAULT 'other',
primary key(product_id)
);

CREATE TABLE cart_product(
cart_product_id int NOT NULL auto_increment,
user_id int not null,
product_id int not null,
units int not null check (units > 0),
primary key (cart_product_id),
foreign key (user_id) references users(user_id) on delete cascade,
foreign key (product_id) references product(product_id) on delete cascade
);

CREATE TABLE feedback(
feedback_id int NOT NULL auto_increment,
user_id int not null,
title varchar(200) not null,
content varchar(3000) not null,
rating int not null,
primary key (feedback_id),
foreign key (user_id) references users(user_id) on delete cascade
);

CREATE TABLE order_set(
order_set_id int NOT NULL auto_increment,
user_id int not null,
issue_date DATETIME not null,
primary key (order_set_id),
foreign key (user_id) references users(user_id) on delete cascade
);

CREATE TABLE order_product(
order_product_id int NOT NULL auto_increment,
product_id int not null,
order_set_id int not null,
units int not null check (units > 0),
current_price_per_unit int not null,
primary key (order_product_id),
foreign key (product_id) references product(product_id),
foreign key (order_set_id) references order_set(order_set_id) on delete cascade
);