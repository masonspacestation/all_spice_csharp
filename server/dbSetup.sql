-- Active: 1717712650110@@52.43.166.8@3306@portfolio
CREATE TABLE IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name varchar(255) COMMENT 'User Name',
    email varchar(255) COMMENT 'User Email',
    picture varchar(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

SELECT * FROM accounts;

CREATE TABLE recipes (
    id INT NOT NULL AUTO_INCREMENT primary key,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    title VARCHAR(255) NOT NULL,
    instructions VARCHAR(5000) NOT NULL,
    img VARCHAR(1000) NOT NULL,
    category ENUM(
        "breakfast",
        "lunch",
        "dinner",
        "snack",
        "dessert"
    ) DEFAULT "dinner",
    creatorId VARCHAR(255) NOT NULL,
    FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
);

DROP TABLE recipes;

SELECT * FROM recipes;

CREATE TABLE ingredients (
    id INT NOT NULL AUTO_INCREMENT primary key,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name VARCHAR(255) NOT NULL,
    quantity VARCHAR(255) NOT NULL,
    recipeId INT NOT NULL,
    creatorId VARCHAR(255) NOT NULL,
    FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE,
    FOREIGN KEY (recipeId) REFERENCES recipes (id) ON DELETE CASCADE
);

SELECT * FROM ingredients;

DROP TABLE ingredients

CREATE TABLE favorites (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    accountId VARCHAR(255) NOT NULL,
    recipeId int NOT NULL,
    FOREIGN KEY (accountId) REFERENCES accounts (id) ON DELETE CASCADE,
    FOREIGN KEY (recipeId) REFERENCES recipes (id) ON DELETE CASCADE,
    UNIQUE (accountId, recipeId)
);

SELECT * FROM favorites;

DROP TABLE favorites;