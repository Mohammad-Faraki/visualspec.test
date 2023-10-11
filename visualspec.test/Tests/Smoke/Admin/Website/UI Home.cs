namespace Tests.Smoke.Admin.Website
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;

    [TestClass]
    public class UI_Home : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Utils.GoToLandingPage(this);
            ExpectLink("Accept", Casing.Exact);
            ClickLink("Accept");

            Expect(What.Contains, "Bring precision to your", Casing.Exact);
            Expect(What.Contains, "vision", Casing.Exact);
            Expect(What.Contains, "Prove what's possible", Casing.Exact);




            Utils.ScrollToElementXPath_Website(this, $"//*[{Utils.XPathTextContains(Casing.Exact, "Prove what")}]");
            Thread.Sleep(3000);
            Expect(What.Contains, "About VisualSpec?", Casing.Exact);
            Expect(What.Contains, "VisualSpec is a rapid software wireframing tool built on a proven solution design framework.", Casing.Exact);

            Expect(What.Contains, "Sample", Casing.Exact);
            Expect(What.Contains, "prototypes", Casing.Exact);
            Expect("View sample", Casing.Exact);



            Utils.ScrollToElementXPath_Website(this, $"//*[{Utils.XPathTextContains(Casing.Exact, "View sample")}]");
            Thread.Sleep(3000);
            Expect(What.Contains, "Interactive", Casing.Exact);
            Expect(What.Contains, "prototyping", Casing.Exact);
            Expect(What.Contains, "Visual Spec is an interactive prototyping tool, used to create low fidelity wireframes for rapid software requirements definition.", Casing.Exact);
            Expect(What.Contains, "No more long spreadsheets and ambiguous user journeys. With visual spec you can capture complex workflows for enterprise scale software 8x faster than a written spec.", Casing.Exact);
            ExpectXPath("//img[@src='/Images/svg/interactive-prototype.svg'][@alt='interactive-prototype']");


            Utils.ScrollToElementXPath_Website(this, $"//*[{Utils.XPathTextContains(Casing.Exact, "No more long spreadsheets and ambiguous")}]");
            Thread.Sleep(3000);
            Expect(What.Contains, "Collaborate in", Casing.Exact);
            Expect(What.Contains, "real time", Casing.Exact);
            Expect(What.Contains, "Visual Spec is designed to enable rapid prototyping so user needs can be validated with stakeholders in real time.", Casing.Exact);
            Expect(What.Contains, "Because it's cloud-based, wireframes can be accessed anywhere in the world, and the inbuilt task features allow your stakeholders to add clarifications or suggest refinements instantly.", Casing.Exact);
            ExpectXPath("//img[@src='/Images/svg/collaborate-in-real-time.svg'][@alt='interactive-prototype']");



            Utils.ScrollToElementXPath_Website(this, $"//*[{Utils.XPathTextContains(Casing.Exact, "clarifications or suggest refinements instantly")}]");
            Thread.Sleep(3000);
            Expect(What.Contains, "A friendly", Casing.Exact);
            Expect(What.Contains, "visual language", Casing.Exact);
            Expect(What.Contains, "By marrying visual representation of requirements with contextual documentation, Visual Spec removes the ambiguity of written specifications.", Casing.Exact);
            Expect(What.Contains, "The clickable low fidelity prototype can be used for getting stakeholder buy-in and early-stage usability testing with users.", Casing.Exact);
            ExpectXPath("//img[@src='/Images/svg/freindly-visual-language.svg'][@alt='freindly-visual-language']");



            Utils.ScrollToElementXPath_Website(this, $"//*[{Utils.XPathTextContains(Casing.Exact, "The clickable low fidelity prototype")}]");
            Thread.Sleep(3000);
            Expect(What.Contains, "Design for", Casing.Exact);
            Expect(What.Contains, "any device", Casing.Exact);
            Expect(What.Contains, "Visual Spec supports requirements capture for desktop, laptop, tablet or mobile screen sizes.", Casing.Exact);
            Expect(What.Contains, "Define each users needs as a distinct point of view, to communicate diverse contexts of use to your sake holders.", Casing.Exact);
            ExpectXPath("//img[@src='/Images/svg/design-for-any-device.svg'][@alt='design for any device']");



            Utils.ScrollToElementXPath_Website(this, $"//*[{Utils.XPathTextContains(Casing.Exact, "Define each users needs as a distinct point of view")}]");
            Thread.Sleep(3000);
            Expect(What.Contains, "100s of software projects have succeeded", Casing.Exact);
            Expect(What.Contains, "with", Casing.Exact);
            Expect(What.Contains, "VisualSpec", Casing.Exact);
            ExpectXPath("//img[@src='/Images/svg/clients-logo.svg'][@alt='our customer']");
        }



    }
}
