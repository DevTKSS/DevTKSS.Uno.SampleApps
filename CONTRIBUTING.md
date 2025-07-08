# Contributing to DevTKSS.Uno.SampleApps

Thank you for your interest in contributing to this project! We welcome contributions from the community.

## Code of Conduct

Please read and follow our [Code of Conduct](CODE_OF_CONDUCT.md) to foster a welcoming and respectful community.

## How to Contribute

1. **Fork the repository** and create your branch from `main`.
2. **Write clear, concise commit messages**.
3. **Test your changes** to ensure they work as expected.
4. **Submit a pull request** with a description of your changes.

## License

By contributing, you agree that your contributions will be licensed under the [Apache License 2.0](LICENSE.md).

## Reporting Issues

If you find a bug or have a feature request, please [open an issue](../../issues).

## Development Guidelines

- Follow Uno Platform best practices.
- Ensure code is clean, well-documented, and tested.
- Adhere to existing coding style and conventions.

Thank you for helping improve DevTKSS.Uno.SampleApps!

## Current Documentation Problems

As workaround to the redirect_url not working, the `[!INCLUDE` Markup is used to include the needed content.

> [!IMPORTANT]
> As DocFx currently also loads explicitly excluded files from the `**/obj/**` folder, the metadata stage does not filter these files out, which can lead to unexpected results in the generated documentation.
