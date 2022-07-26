create table tbl_ProductInfo 
(
    productId int Identity,
    productName varchar(30) not null,
    productType varchar(30) not null,
    productGenre varchar(30) not null,
    productPlatform varchar(30) not null,
    productManufacturer varchar(30) not null,
    productReleaseDate int,
    productCost money,
    productQty int,
    productIsInStock bit,
    constraint pk_productId PRIMARY KEY(productId),
    constraint unk_productName UNIQUE(productName)
)

create table tbl_ProductRanking
(
    productId int,
    productName varchar(30) not null,
    productRanking int,
    constraint pk_productId2 PRIMARY KEY(productId),
    constraint fk_productName foreign Key(productName) references tbl_ProductInfo (productName)
)
create table tbl_RegisterInfo
(
    userName varchar(30),
    userPassword varchar(15) not null,
    firstName varchar(30) not null,
    lastName varchar(30) not null,
    stAddress varchar(40) not null,
    city varchar(20) not null,
    customerState varchar (20),
    userPoints int,
    constraint pk_userName PRIMARY KEY(userName),
    constraint chk_userPwd_len check(len(userPassword) > 5)
)

create table tbl_CustomerContact
(
    userName varchar(30),
    emailAddress varchar(30) not null,
    contactNo int,
    constraint pk_userName2 PRIMARY KEY(userName),
    constraint fk_emailAddress foreign Key (emailAddress) references tbl_RegisterInfo (userName),
    constraint unk_contactNo UNIQUE(contactNo)
)

create table tbl_OrdersInfo
(
    orderNo int identity,
    orderName varchar(30) not null,
    orderPrice money not null,
    paymentType varchar(20) not null,
    orderDate date not null,
    pointsEarned int,
    constraint pk_orderNo PRIMARY KEY(orderNo),
    constraint chk_paymentType CHECK(paymentType in('Visa', 'Mastercard', 'American Express', 'Discover', 'Apple Pay', 'Google Pay', 'Customer Points', 'Trade-In')),
    constraint fk_orderName foreign Key (orderName) references tbl_RegisterInfo (userName)
)

create table tbl_ProductCostList
(
    productId int,
    productName varchar(30),
    productPrice money not null,
    constraint pk_productName PRIMARY KEY(productName),
    constraint fk_productId foreign Key(productId) references tbl_ProductInfo
)

create table tbl_ProductsPurchased
(
    orderNo int not null,
    productName varchar(30) not null,
    orderQty int not null,
    constraint pk_orderName PRIMARY KEY(orderNo, productName),
    constraint fk_orderNo foreign Key (orderNo) references tbl_OrdersInfo,
    constraint fk_productName2 foreign Key (productName) references tbl_ProductCostList (productName)
)

drop table tbl_ProductsPurchased
drop table tbl_ProductCostList
drop table tbl_OrdersInfo
drop table tbl_CustomerContact
drop table tbl_RegisterInfo
drop table tbl_ProductRanking
drop table tbl_ProductInfo

select * from tbl_ProductInfo
select * from tbl_RegisterInfo