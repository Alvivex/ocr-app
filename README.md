# OCR App

A cross-platform optical character recognition application that accurately recognizes and converts alphanumeric characters to digital format using a custom-trained neural network.

## Features

- **Custom-Trained Neural Network**: High-accuracy character recognition powered by TensorFlow
- **Modern Desktop UI**: Intuitive C# frontend for seamless user experience
- **Alphanumeric Support**: Recognizes letters, numbers, and common special characters
- **Production-Ready**: Optimized inference pipeline for real-time processing

## Tech Stack

- **Frontend**: C# (.NET)
- **ML Backend**: Python with TensorFlow
- **Model Training**: Custom neural network architecture

## Getting Started

### Prerequisites

- .NET Framework/Core (for frontend)
- Python 3.8+ with TensorFlow (for model training/inference)

### Installation

1. Clone the repository:
```bash
git clone https://github.com/Alvivex/ocr-app.git
cd ocr-app
```

2. Install dependencies:
   - For the frontend: Restore NuGet packages
   - For the backend: Install Python dependencies from `requirements.txt`

### Usage

```bash
# Run the application
dotnet run
```

## Project Structure

- `/frontend` - C# WPF/WinForms application
- `/backend` - Python TensorFlow model and inference service
- `/models` - Trained neural network weights and configuration

## Contributing

Contributions are welcome! Please feel free to submit pull requests or open issues for bugs and feature requests.

## License

This project is licensed under the MIT License - see the LICENSE file for details.

---

**Built with precision. Powered by neural networks.**
