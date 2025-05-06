# 📓🔒**Digital Diary** 

### **File Handling Activity in C#**

## Project Description

The Digital Diary Application is a secure diary management system that allows users to write, view, and search diary entries. The entries are encrypted using a simple Caesar cipher to ensure privacy. The application provides the following features:

## Features

- ✍️**Write a New Entry**: Users can add new diary entries.
- 📖**View All Entries**: Users can view all diary entries, both encrypted and decrypted.
- 🔍**Search Entry by Date**: Users can search for entries by a specific date, with password protection for access.
- 🚪**Exit**: Users can exit the application gracefully.

## 🔐Explanation of SecureDiary.cs 

The `SecureDiary` class inherits from the base `Diary` class and adds an extra layer of security by encrypting all diary entries before saving them to the file and decrypting them when they are read back. It uses a simple Caesar cipher with a fixed shift to encrypt and decrypt the content. Key features include:

- Overriding `WriteEntry` to automatically encrypt user input before writing to the file.
- Overriding `ViewAllEntries` to decrypt entries when viewed with the correct password.
- A `GetEncryptedEntries` method to show entries in their encrypted form.
- A `SearchByDate` method that allows searching for entries on a specific date with decryption.
- Internal `Encrypt` and `Decrypt` methods that perform the Caesar cipher character shifting.

This implementation ensures that diary entries are stored securely and can only be decrypted by someone who has the password.

## How OOP Principles are Used

The application utilizes several Object-Oriented Programming (OOP) principles:

- **Encapsulation**: The `Diary` and `SecureDiary` classes encapsulate the functionality related to diary management and encryption, respectively.
- **Inheritance**: The `SecureDiary` class inherits from the `Diary` class, allowing it to extend the functionality of the base class while maintaining a clear structure.
- **Polymorphism**: The `WriteEntry` and `ViewAllEntries` methods are overridden in the `SecureDiary` class to provide specific behavior for encrypted entries.
- **Abstraction**: The implementation details of encryption and file handling are abstracted away from the user, providing a simple interface for diary management.

## Instructions on Running the App

1. Ensure you have .NET SDK installed on your machine.
2. Clone the repository or download the source code files.
3. Open a terminal or command prompt and navigate to the project directory.
4. Compile the application using the command: 
```

   dotnet build

```
5. Run the application using the command: 
```

   dotnet run

```
6. Follow the on-screen instructions to interact with the diary.

## File Structure
```

/DigitalDiary
│
├── Program.cs          // Main application logic
├── Diary.cs            // Base diary class
└── SecureDiary.cs      // Derived class with encryption features

```

## Sample Output
```

\--- DIGITAL DIARY ---

1. Write a New Entry
2. View All Entries
3. Search Entry by Date
4. Exit

Enter your choice: 1

Enter your diary entry (x to cancel): Today was a great day!

Entry added.

Press any key to continue...

\--- DIGITAL DIARY ---

1. Write a New Entry
2. View All Entries
3. Search Entry by Date
4. Exit

Enter your choice: 2

\--- Encrypted Entries ---
Wkhq wdv d juhdw gd!

Enter password to view decrypted entries (or 'x' to return): Group 1

\--- Decrypted Entries ---
Today was a great day!

Press any key to continue...

```

## Team Members

| Name                   | Student Code                 |
|------------------------|------------------------------|
| Albert Soriano Jr      | 23-03014@g.batstate-u.edu.ph |
| Jerzha Ara Ramil Lalu  | 23-05464@g.batstate-u.edu.ph |
| John Richnell Catibog  | 23-04985@g.batstate-u.edu.ph |
| Kent Ian Ramirez       | 23-00686@g.batstate-u.edu.ph |

## Acknowledgement

We would like to thank our instructor, Ms. Fatima Marie Agdon, for their support and feedback during the development of this project. Special thanks to the open-source community for providing resources and libraries that helped us implement encryption and file handling.
