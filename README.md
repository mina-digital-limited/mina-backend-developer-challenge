# Mina Backend Developer Challenge

If you've been asked to take this challenge, then we think you could have what it takes to join the backend development team at Mina.

The purpose of this challenge is to assess your coding and problem-solving skills. It's also an opportunity for us to demonstrate how we like to write our code, and for you to see what kind of work you might be doing.

## Background information

Mina receives charge session data from a large number of sources and we normalise it before it can be ingested. Each source provides data in a different shape and we need to ensure that essential information can be extraced:

- EVSE (Electric Vehicle Supply Equipment) unique identifier
- Start date/time of the charge session
- End date/time of the charge session
- Total consumption, either in Wh or kWh
- Charge session unique identifier (optional)

If any of the mandatory data is missing, invalid, or violates other rules (e.g. duplicate/overalapping), the entire ingress process is adandoned.

## What to do

The solution contains two projects - a simple class library, and a corresponding test project.

The class library contains the skeleton for a service (`TeslaChargeSessionIngestionService`) which is responsible for ingesting raw charge session data. The service is responsible for:

- normalising charge sessions
- rejecting invalid charge sessions
- rejecting duplicate charge sessions
- rejecting overlapping charge sessions

Your task is to implement this service.

To aid you, there are a number of failing unit tests in the test project. These should all pass if you implement the service correctly. However, the existing tests do not cover all scenarios; you are encouraged to write additional tests.

## How to submit your code

- Create a private fork of this repository
- Push your working solution to your fork
- Create a pull request from your fork to this repository, and add your hiring manager as a reviewer (bonus points for a demo video in the PR)
- Email your hiring manager with confirmation that your PR is ready for review

## Rubric

Nobody does perfectly on challenges like this, and that's fine. We're not looking for perfection, we're looking to assess your approach to solving problems.

For a full breakdown of how you are evaluated during the inteview process, view our [grading rubric](./rubric.md).

## Feedback

We’re always looking for ways we can improve our process, so please send us your thoughts. Thanks for taking the time to interview with us and good luck!
