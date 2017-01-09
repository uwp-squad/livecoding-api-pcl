﻿using LivecodingApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecodingApi.Helpers
{
    internal static class PaginationHelper
    {
        public static string CreateHttpQueryParams(PaginationRequest request)
        {
            var parameters = new Dictionary<string, string>();

            if (request.Page > 1)
            {
                int offset = request.ItemsPerPage * (request.Page - 1);
                parameters.Add("offset", offset.ToString());
            }

            if (request.ItemsPerPage != 100)
            {
                parameters.Add("limit", request.ItemsPerPage.ToString());
            }

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                parameters.Add("search", request.Search);
            }

            if (!string.IsNullOrWhiteSpace(request.Ordering))
            {
                string orderingValue = (request.DescendingOrdering ? "-" : string.Empty) + request.Ordering;
                parameters.Add("ordering", orderingValue);
            }

            foreach (var filter in request.Filters)
            {
                parameters.Add(filter.Key, filter.Value);
            }

            if (parameters.Count > 0)
            {
                return "?" + string.Join("&", parameters.Select(p => $"{p.Key}={p.Value}"));
            }

            return "";
        }

        public static PaginationResult<T> FillWithPaginationRequest<T>(this PaginationResult<T> result, PaginationRequest request)
        {
            result.Page = request.Page;
            result.ItemsPerPage = request.ItemsPerPage;
            result.Search = request.Search;
            result.Ordering = request.Ordering;
            result.DescendingOrdering = request.DescendingOrdering;
            result.Filters = request.Filters;
            return result;
        }

        public static Task<PaginationResult<T>> PaginationContinuation<T>(this Task<PaginationResult<T>> task, PaginationRequest request)
        {
            return task.ContinueWith(t =>
            {
                if (t.Exception != null)
                    throw t.Exception.InnerException;

                return t.Result.FillWithPaginationRequest(request);
            });
        }
    }
}
