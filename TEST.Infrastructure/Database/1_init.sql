CREATE TABLE permission_types (
    id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    description varchar(100) NOT NULL
);


CREATE TABLE permissions_ (
    id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    name varchar(100) NOT NULL,
    last_name varchar(100) NOT NULL,
    permission_type_id INT NOT NULL,
    date varchar(100) NOT NULL,
    CONSTRAINT fk_permission_type_id FOREIGN KEY(permission_type_id) REFERENCES permission_types(id)
    
);

INSERT INTO permission_types ( description) VALUES
    ('Enfermedad')
   ,('Diligencias')
   ,('Otros')
    