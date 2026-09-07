# Outlook AI Assistant

Outlook AI Assistant is a VSTO add-in for Classic Microsoft Outlook. It adds AI-assisted email tools directly to the Outlook ribbon, so common tasks such as drafting, correcting, translating, and replying to emails can be completed without switching to a separate AI application.

The project was built in C# with .NET Framework and uses the Gemini API to process AI requests.

## Features

The AI Assist ribbon provides five features:

- **Generate Email** - Creates an email subject and body from user instructions. The user can select a professional or casual tone and choose a short, medium, or long email.
- **Spell Check** - Corrects spelling, grammar, and punctuation in the subject and body of the active email.
- **Language Conversion** - Translates the subject and body of the active email into Hindi, Urdu, Spanish, German, French, or Malayalam.
- **Reply Assist** - Generates a reply from the email context and the user's instructions, then opens it as a new Outlook reply for review before sending.
- **AI Chatbot** - Provides a small in-Outlook chat interface for general assistance. It keeps the current conversation in memory until the user starts a new chat.

## Architecture

The add-in separates the Outlook user interface, feature logic, AI communication, and data models:

```text
Outlook AI Assist Ribbon
          |
          v
Forms (collect user input)
          |
          v
Feature services (create task-specific prompts)
          |
          v
GeminiService (shared HttpClient API communication)
          |
          v
Gemini API
          |
          v
Outlook email or chatbot interface
```

- **Ribbon** contains the five feature buttons.
- **ThisAddIn** connects the project to Outlook and provides access to the active Outlook application.
- **Forms** collect input such as email instructions, tone, length, translation language, and reply context.
- **Services** contain the feature logic. Each service uses the shared `GeminiService` instead of implementing API communication separately.
- **Models** hold and transfer data, such as email generation requests/responses and chatbot messages.

## Tech Stack

- C#
- .NET Framework
- Visual Studio Tools for Office (VSTO)
- Classic Microsoft Outlook
- Windows Forms
- Gemini API
- `HttpClient`

## Gemini API Integration

Each feature creates a prompt suited to its task. For example, email generation includes the user's instructions, tone, and length; translation includes the selected language; and reply assistance or chatbot requests include the relevant email or conversation context.

These prompts are sent through the shared `GeminiService`. The service reads the Gemini API key and endpoint from `App.config`, sends the request using `HttpClient`, and returns the response to the relevant feature service.

> Do not commit a real API key. Keep your own `App.config` values private or use a local configuration approach before pushing the project to GitHub.

## Prerequisites

Before running the project, make sure you have:

- Windows
- Classic Microsoft Outlook
- Visual Studio with the Microsoft 365 development workload / Office development tools for VSTO
- The required .NET Framework components
- A Gemini API key and API endpoint
- An internet connection

## Setup and Run

1. Open the solution in Visual Studio.
2. In `App.config`, configure the Gemini API key and endpoint used by `GeminiService`.
3. Build the solution and resolve any build errors.
4. Start the project from Visual Studio.
5. Classic Outlook should open with the **AI Assist** ribbon available.

Open or compose an email before using a feature that works with the active Outlook email.

## Error Handling

The add-in validates required input before sending an AI request, such as email instructions, selected options, reply context, and an active email item where needed. It also handles common API and application problems at a high level, including:

- Missing or invalid API keys
- Rate limits and unsuccessful API responses
- Network failures and request timeouts
- Empty AI responses
- No active Outlook inspector or an active item that is not an email

Loading feedback is shown while AI requests are in progress. If an error occurs, the add-in displays a message instead of allowing the feature to fail silently or crash.

## Future Enhancements

- Save chatbot conversations so they remain available after Outlook is closed
- Add more translation languages
- Support newer Outlook versions beyond the Classic Outlook VSTO environment
- Improve the user interface

## Notes

This project is intended for use with Classic Microsoft Outlook because it is built as a VSTO add-in.
