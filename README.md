# Hamming SEC-DED Code Simulator (C#)

This is a C# Windows Forms application that simulates Hamming SEC-DED (Single Error Correction, Double Error Detection) encoding and decoding. Users can input 8, 16, or 32-bit binary data, apply Hamming encoding, inject single-bit errors, and then detect and correct them.

## 🚀 Features

- Support for 8-bit, 16-bit, and 32-bit input
- Hamming SEC-DED encoding of binary data
- Simulated memory write and read operations
- Interactive error bit selection via buttons
- Automatic error detection and correction

## 📁 Project Structure

📁 Busra_Uzunlar_Mimari_Proje  
├── anaMenu.cs // Main form and UI logic  
├── Program.cs // Entry point  
├── Busra_Uzunlar_Mimari_Proje.csproj  
├── Classes/  
│ ├── hammingCoder.cs // Hamming encode/decode logic  
│ └── memory.cs // Simulated memory operations  


## 🧠 Components

- `anaMenu.cs`: Handles user interactions and GUI logic
- `hammingCoder.cs`: Contains encoding and decoding logic for Hamming SEC-DED
- `memory.cs`: Manages simulated memory storage and error injection

## 🎥 Demo Video

You can watch the demo of this project on YouTube:  
[▶️ Watch the video here](https://youtu.be/azOLMMzpnjs)


## 🛠 How to Run

1. Clone or download this repository
2. Open the solution file (`.sln`) in Visual Studio
3. Build and run the project
4. Use the form to:
   - Enter binary data
   - Encode it
   - Inject an error
   - Decode and fix it

## 📃 License

This project is licensed under the MIT License – feel free to use and modify it.
