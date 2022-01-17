CREATE TABLE tab_persons
(
    id         INT          NOT NULL AUTO_INCREMENT PRIMARY KEY,
    first_name VARCHAR(50)  NOT NULL,
    last_name  VARCHAR(100) NOT NULL
);

CREATE TABLE tab_subjects
(
    id   INT         NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(50) NOT NULL
);

CREATE TABLE tab_faculties
(
    id   INT         NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(50) NOT NULL
);

CREATE TABLE tab_groups
(
    id         INT         NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name       VARCHAR(50) NOT NULL,
    faculty_id INT         NOT NULL,
    FOREIGN KEY (faculty_id) REFERENCES tab_faculties (id)
        ON DELETE NO ACTION
        ON UPDATE NO ACTION
);

CREATE TABLE tab_students
(
    id        INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    person_id INT NOT NULL,
    group_id  INT NOT NULL,
    FOREIGN KEY (person_id) REFERENCES tab_persons (id)
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    FOREIGN KEY (group_id) REFERENCES tab_groups (id)
        ON DELETE NO ACTION
        ON UPDATE NO ACTION
);

CREATE TABLE tab_grades
(
    id        INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    student_id INT NOT NULL,
    subject_id  INT NOT NULL,
    FOREIGN KEY (student_id ) REFERENCES tab_students (id)
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    FOREIGN KEY (subject_id) REFERENCES tab_subjects (id)
        ON DELETE NO ACTION
        ON UPDATE NO ACTION
);