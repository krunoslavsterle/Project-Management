﻿using PM.Common.Enums;
using System;
using System.Web.Mvc;

namespace PM.Web.Infrastructure.HtmlHelpers
{
    /// <summary>
    /// Html helpers methods.
    /// </summary>
    public static class HtmlHelpers
    {
        /// <summary>
        /// Creates the menu item link, handles the active state.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="text">The text of the link.</param>
        /// <param name="action">The action name.</param>
        /// <param name="controller">The controller name.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="iconClass">The icon class.</param>
        /// <returns>Html link.</returns>
        public static MvcHtmlString MenuItemLink(this HtmlHelper helper, string text, string action, string controller, object routeValues = null, string iconClass = "")
        {
            var context = helper.ViewContext;
            if (context.Controller.ControllerContext.IsChildAction)
                context = helper.ViewContext.ParentActionViewContext;

            var routeData = context.RouteData.Values;
            var currentAction = routeData["action"].ToString();
            var currentController = routeData["controller"].ToString();

            var linkClass = currentAction.Equals(action, StringComparison.InvariantCulture) && currentController.Equals(controller, StringComparison.InvariantCulture) ? 
                "nav-item-active" : String.Empty;

            UrlHelper urlHelper = new UrlHelper(context.RequestContext);
            var linkHref = urlHelper.Action(action, controller, routeValues);
            var htmlStr = String.Format("<a class='{0}' href='{1}'><i class='{2}'></i><span>{3}</span></a>", linkClass, linkHref, iconClass, text);

            return new MvcHtmlString(htmlStr);
        }

        /// <summary>
        /// Creates the dashboard activity icon based on activityType and activityMagnitude.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="activityType">Type of the activity.</param>
        /// <param name="magnitude">The activity magnitude.</param>
        /// <returns>Dashboard activity icon.</returns>
        public static MvcHtmlString DashboardActivity(this HtmlHelper helper, ActivityType activityType, ActivityMagnitude magnitude)
        {
            string baseCss = "activity-icon glyphicon";
            // TODO: - DashboardActivity - USE STRING BUILDER.
            switch (activityType)
            {
                case ActivityType.System:
                    baseCss += " "; // TODO - DashboardActivity HTML HELPER.
                    break;
                case ActivityType.Profile:
                    baseCss += " glyphicon-tag"; // TODO - DashboardActivity HTML HELPER.
                    break;
                case ActivityType.Project:
                    baseCss += " glyphicon-flag";
                    break;
                case ActivityType.Task:
                    baseCss += " glyphicon-flash";
                    break;
                default:
                    break;
            }

            switch (magnitude)
            {
                case ActivityMagnitude.Low:
                    baseCss += " color-general";
                    break;
                case ActivityMagnitude.Medium:
                    baseCss += " color-warning";
                    break;
                case ActivityMagnitude.High:
                    baseCss += " color-alert";
                    break;
                default:
                    break;
            }

            string htmlStr = String.Format("<i class='{0}'></i>", baseCss);
            return new MvcHtmlString(htmlStr);
        }
    }
}
