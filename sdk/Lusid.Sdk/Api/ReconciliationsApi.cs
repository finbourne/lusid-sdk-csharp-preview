/*
 * LUSID API
 *
 * # Introduction  This page documents the [LUSID APIs](../../../api/swagger), which allows authorised clients to query and update their data within the LUSID platform.  SDKs to interact with the LUSID APIs are available in the following languages and frameworks:  * [C#](https://github.com/finbourne/lusid-sdk-csharp) * [Java](https://github.com/finbourne/lusid-sdk-java) * [JavaScript](https://github.com/finbourne/lusid-sdk-js) * [Python](https://github.com/finbourne/lusid-sdk-python) * [Angular](https://github.com/finbourne/lusid-sdk-angular)  The LUSID platform is made up of a number of sub-applications. You can find the API / swagger documentation by following the links in the table below.   | Application   | Description                                                                       | API / Swagger Documentation                          | |- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -| | LUSID         | Open, API-first, developer-friendly investment data platform.                     | [Swagger](../../../api/swagger/index.html)           | | Web app       | User-facing front end for LUSID.                                                  | [Swagger](../../../app/swagger/index.html)           | | Scheduler     | Automated job scheduler.                                                          | [Swagger](../../../scheduler2/swagger/index.html)    | | Insights      | Monitoring and troubleshooting service.                                           | [Swagger](../../../insights/swagger/index.html)      | | Identity      | Identity management for LUSID (in conjunction with Access)                        | [Swagger](../../../identity/swagger/index.html)      | | Access        | Access control for LUSID (in conjunction with Identity)                           | [Swagger](../../../access/swagger/index.html)        | | Drive         | Secure file repository and manager for collaboration.                             | [Swagger](../../../drive/swagger/index.html)         | | Luminesce     | Data virtualisation service (query data from multiple providers, including LUSID) | [Swagger](../../../honeycomb/swagger/index.html)     | | Notification  | Notification service.                                                             | [Swagger](../../../notification/swagger/index.html)  | | Configuration | File store for secrets and other sensitive information.                           | [Swagger](../../../configuration/swagger/index.html) | | Workflow      | Workflow service.                                                                 | [Swagger](../../../workflow/swagger/index.html)      |   # Error Codes  | Code|Name|Description | | - --|- --|- -- | | <a name=\"-10\">-10</a>|Server Configuration Error|  | | <a name=\"-1\">-1</a>|Unknown error|An unexpected error was encountered on our side. | | <a name=\"102\">102</a>|Version Not Found|  | | <a name=\"103\">103</a>|Api Rate Limit Violation|  | | <a name=\"104\">104</a>|Instrument Not Found|  | | <a name=\"105\">105</a>|Property Not Found|  | | <a name=\"106\">106</a>|Portfolio Recursion Depth|  | | <a name=\"108\">108</a>|Group Not Found|  | | <a name=\"109\">109</a>|Portfolio Not Found|  | | <a name=\"110\">110</a>|Property Schema Not Found|  | | <a name=\"111\">111</a>|Portfolio Ancestry Not Found|  | | <a name=\"112\">112</a>|Portfolio With Id Already Exists|  | | <a name=\"113\">113</a>|Orphaned Portfolio|  | | <a name=\"119\">119</a>|Missing Base Claims|  | | <a name=\"121\">121</a>|Property Not Defined|  | | <a name=\"122\">122</a>|Cannot Delete System Property|  | | <a name=\"123\">123</a>|Cannot Modify Immutable Property Field|  | | <a name=\"124\">124</a>|Property Already Exists|  | | <a name=\"125\">125</a>|Invalid Property Life Time|  | | <a name=\"126\">126</a>|Property Constraint Style Excludes Properties|  | | <a name=\"127\">127</a>|Cannot Modify Default Data Type|  | | <a name=\"128\">128</a>|Group Already Exists|  | | <a name=\"129\">129</a>|No Such Data Type|  | | <a name=\"130\">130</a>|Undefined Value For Data Type|  | | <a name=\"131\">131</a>|Unsupported Value Type Defined On Data Type|  | | <a name=\"132\">132</a>|Validation Error|  | | <a name=\"133\">133</a>|Loop Detected In Group Hierarchy|  | | <a name=\"134\">134</a>|Undefined Acceptable Values|  | | <a name=\"135\">135</a>|Sub Group Already Exists|  | | <a name=\"138\">138</a>|Price Source Not Found|  | | <a name=\"139\">139</a>|Analytic Store Not Found|  | | <a name=\"141\">141</a>|Analytic Store Already Exists|  | | <a name=\"143\">143</a>|Client Instrument Already Exists|  | | <a name=\"144\">144</a>|Duplicate In Parameter Set|  | | <a name=\"147\">147</a>|Results Not Found|  | | <a name=\"148\">148</a>|Order Field Not In Result Set|  | | <a name=\"149\">149</a>|Operation Failed|  | | <a name=\"150\">150</a>|Elastic Search Error|  | | <a name=\"151\">151</a>|Invalid Parameter Value|  | | <a name=\"153\">153</a>|Command Processing Failure|  | | <a name=\"154\">154</a>|Entity State Construction Failure|  | | <a name=\"155\">155</a>|Entity Timeline Does Not Exist|  | | <a name=\"156\">156</a>|Concurrency Conflict Failure|  | | <a name=\"157\">157</a>|Invalid Request|  | | <a name=\"158\">158</a>|Event Publish Unknown|  | | <a name=\"159\">159</a>|Event Query Failure|  | | <a name=\"160\">160</a>|Blob Did Not Exist|  | | <a name=\"162\">162</a>|Sub System Request Failure|  | | <a name=\"163\">163</a>|Sub System Configuration Failure|  | | <a name=\"165\">165</a>|Failed To Delete|  | | <a name=\"166\">166</a>|Upsert Client Instrument Failure|  | | <a name=\"167\">167</a>|Illegal As At Interval|  | | <a name=\"168\">168</a>|Illegal Bitemporal Query|  | | <a name=\"169\">169</a>|Invalid Alternate Id|  | | <a name=\"170\">170</a>|Cannot Add Source Portfolio Property Explicitly|  | | <a name=\"171\">171</a>|Entity Already Exists In Group|  | | <a name=\"172\">172</a>|Entity With Id Does Not Exist|  | | <a name=\"173\">173</a>|Entity With Id Already Exists|  | | <a name=\"174\">174</a>|Derived Portfolio Details Do Not Exist|  | | <a name=\"175\">175</a>|Entity Not In Group|  | | <a name=\"176\">176</a>|Portfolio With Name Already Exists|  | | <a name=\"177\">177</a>|Invalid Transactions|  | | <a name=\"178\">178</a>|Reference Portfolio Not Found|  | | <a name=\"179\">179</a>|Duplicate Id|  | | <a name=\"180\">180</a>|Command Retrieval Failure|  | | <a name=\"181\">181</a>|Data Filter Application Failure|  | | <a name=\"182\">182</a>|Search Failed|  | | <a name=\"183\">183</a>|Movements Engine Configuration Key Failure|  | | <a name=\"184\">184</a>|Fx Rate Source Not Found|  | | <a name=\"185\">185</a>|Accrual Source Not Found|  | | <a name=\"186\">186</a>|Access Denied|  | | <a name=\"187\">187</a>|Invalid Identity Token|  | | <a name=\"188\">188</a>|Invalid Request Headers|  | | <a name=\"189\">189</a>|Price Not Found|  | | <a name=\"190\">190</a>|Invalid Sub Holding Keys Provided|  | | <a name=\"191\">191</a>|Duplicate Sub Holding Keys Provided|  | | <a name=\"192\">192</a>|Cut Definition Not Found|  | | <a name=\"193\">193</a>|Cut Definition Invalid|  | | <a name=\"194\">194</a>|Time Variant Property Deletion Date Unspecified|  | | <a name=\"195\">195</a>|Perpetual Property Deletion Date Specified|  | | <a name=\"196\">196</a>|Time Variant Property Upsert Date Unspecified|  | | <a name=\"197\">197</a>|Perpetual Property Upsert Date Specified|  | | <a name=\"200\">200</a>|Invalid Unit For Data Type|  | | <a name=\"201\">201</a>|Invalid Type For Data Type|  | | <a name=\"202\">202</a>|Invalid Value For Data Type|  | | <a name=\"203\">203</a>|Unit Not Defined For Data Type|  | | <a name=\"204\">204</a>|Units Not Supported On Data Type|  | | <a name=\"205\">205</a>|Cannot Specify Units On Data Type|  | | <a name=\"206\">206</a>|Unit Schema Inconsistent With Data Type|  | | <a name=\"207\">207</a>|Unit Definition Not Specified|  | | <a name=\"208\">208</a>|Duplicate Unit Definitions Specified|  | | <a name=\"209\">209</a>|Invalid Units Definition|  | | <a name=\"210\">210</a>|Invalid Instrument Identifier Unit|  | | <a name=\"211\">211</a>|Holdings Adjustment Does Not Exist|  | | <a name=\"212\">212</a>|Could Not Build Excel Url|  | | <a name=\"213\">213</a>|Could Not Get Excel Version|  | | <a name=\"214\">214</a>|Instrument By Code Not Found|  | | <a name=\"215\">215</a>|Entity Schema Does Not Exist|  | | <a name=\"216\">216</a>|Feature Not Supported On Portfolio Type|  | | <a name=\"217\">217</a>|Quote Not Found|  | | <a name=\"218\">218</a>|Invalid Quote Identifier|  | | <a name=\"219\">219</a>|Invalid Metric For Data Type|  | | <a name=\"220\">220</a>|Invalid Instrument Definition|  | | <a name=\"221\">221</a>|Instrument Upsert Failure|  | | <a name=\"222\">222</a>|Reference Portfolio Request Not Supported|  | | <a name=\"223\">223</a>|Transaction Portfolio Request Not Supported|  | | <a name=\"224\">224</a>|Invalid Property Value Assignment|  | | <a name=\"230\">230</a>|Transaction Type Not Found|  | | <a name=\"231\">231</a>|Transaction Type Duplication|  | | <a name=\"232\">232</a>|Portfolio Does Not Exist At Given Date|  | | <a name=\"233\">233</a>|Query Parser Failure|  | | <a name=\"234\">234</a>|Duplicate Constituent|  | | <a name=\"235\">235</a>|Unresolved Instrument Constituent|  | | <a name=\"236\">236</a>|Unresolved Instrument In Transition|  | | <a name=\"237\">237</a>|Missing Side Definitions|  | | <a name=\"240\">240</a>|Duplicate Calculations Failure|  | | <a name=\"299\">299</a>|Invalid Recipe|  | | <a name=\"300\">300</a>|Missing Recipe|  | | <a name=\"301\">301</a>|Dependencies|  | | <a name=\"304\">304</a>|Portfolio Preprocess Failure|  | | <a name=\"310\">310</a>|Valuation Engine Failure|  | | <a name=\"311\">311</a>|Task Factory Failure|  | | <a name=\"312\">312</a>|Task Evaluation Failure|  | | <a name=\"313\">313</a>|Task Generation Failure|  | | <a name=\"314\">314</a>|Engine Configuration Failure|  | | <a name=\"315\">315</a>|Model Specification Failure|  | | <a name=\"320\">320</a>|Market Data Key Failure|  | | <a name=\"321\">321</a>|Market Resolver Failure|  | | <a name=\"322\">322</a>|Market Data Failure|  | | <a name=\"330\">330</a>|Curve Failure|  | | <a name=\"331\">331</a>|Volatility Surface Failure|  | | <a name=\"332\">332</a>|Volatility Cube Failure|  | | <a name=\"350\">350</a>|Instrument Failure|  | | <a name=\"351\">351</a>|Cash Flows Failure|  | | <a name=\"352\">352</a>|Reference Data Failure|  | | <a name=\"360\">360</a>|Aggregation Failure|  | | <a name=\"361\">361</a>|Aggregation Measure Failure|  | | <a name=\"370\">370</a>|Result Retrieval Failure|  | | <a name=\"371\">371</a>|Result Processing Failure|  | | <a name=\"372\">372</a>|Vendor Result Processing Failure|  | | <a name=\"373\">373</a>|Vendor Result Mapping Failure|  | | <a name=\"374\">374</a>|Vendor Library Unauthorised|  | | <a name=\"375\">375</a>|Vendor Connectivity Error|  | | <a name=\"376\">376</a>|Vendor Interface Error|  | | <a name=\"377\">377</a>|Vendor Pricing Failure|  | | <a name=\"378\">378</a>|Vendor Translation Failure|  | | <a name=\"379\">379</a>|Vendor Key Mapping Failure|  | | <a name=\"380\">380</a>|Vendor Reflection Failure|  | | <a name=\"381\">381</a>|Vendor Process Failure|  | | <a name=\"382\">382</a>|Vendor System Failure|  | | <a name=\"390\">390</a>|Attempt To Upsert Duplicate Quotes|  | | <a name=\"391\">391</a>|Corporate Action Source Does Not Exist|  | | <a name=\"392\">392</a>|Corporate Action Source Already Exists|  | | <a name=\"393\">393</a>|Instrument Identifier Already In Use|  | | <a name=\"394\">394</a>|Properties Not Found|  | | <a name=\"395\">395</a>|Batch Operation Aborted|  | | <a name=\"400\">400</a>|Invalid Iso4217 Currency Code|  | | <a name=\"401\">401</a>|Cannot Assign Instrument Identifier To Currency|  | | <a name=\"402\">402</a>|Cannot Assign Currency Identifier To Non Currency|  | | <a name=\"403\">403</a>|Currency Instrument Cannot Be Deleted|  | | <a name=\"404\">404</a>|Currency Instrument Cannot Have Economic Definition|  | | <a name=\"405\">405</a>|Currency Instrument Cannot Have Lookthrough Portfolio|  | | <a name=\"406\">406</a>|Cannot Create Currency Instrument With Multiple Identifiers|  | | <a name=\"407\">407</a>|Specified Currency Is Undefined|  | | <a name=\"410\">410</a>|Index Does Not Exist|  | | <a name=\"411\">411</a>|Sort Field Does Not Exist|  | | <a name=\"413\">413</a>|Negative Pagination Parameters|  | | <a name=\"414\">414</a>|Invalid Search Syntax|  | | <a name=\"415\">415</a>|Filter Execution Timeout|  | | <a name=\"420\">420</a>|Side Definition Inconsistent|  | | <a name=\"450\">450</a>|Invalid Quote Access Metadata Rule|  | | <a name=\"451\">451</a>|Access Metadata Not Found|  | | <a name=\"452\">452</a>|Invalid Access Metadata Identifier|  | | <a name=\"460\">460</a>|Standard Resource Not Found|  | | <a name=\"461\">461</a>|Standard Resource Conflict|  | | <a name=\"462\">462</a>|Calendar Not Found|  | | <a name=\"463\">463</a>|Date In A Calendar Not Found|  | | <a name=\"464\">464</a>|Invalid Date Source Data|  | | <a name=\"465\">465</a>|Invalid Timezone|  | | <a name=\"601\">601</a>|Person Identifier Already In Use|  | | <a name=\"602\">602</a>|Person Not Found|  | | <a name=\"603\">603</a>|Cannot Set Identifier|  | | <a name=\"617\">617</a>|Invalid Recipe Specification In Request|  | | <a name=\"618\">618</a>|Inline Recipe Deserialisation Failure|  | | <a name=\"619\">619</a>|Identifier Types Not Set For Entity|  | | <a name=\"620\">620</a>|Cannot Delete All Client Defined Identifiers|  | | <a name=\"650\">650</a>|The Order requested was not found.|  | | <a name=\"654\">654</a>|The Allocation requested was not found.|  | | <a name=\"655\">655</a>|Cannot build the fx forward target with the given holdings.|  | | <a name=\"656\">656</a>|Group does not contain expected entities.|  | | <a name=\"665\">665</a>|Destination directory not found|  | | <a name=\"667\">667</a>|Relation definition already exists|  | | <a name=\"672\">672</a>|Could not retrieve file contents|  | | <a name=\"673\">673</a>|Missing entitlements for entities in Group|  | | <a name=\"674\">674</a>|Next Best Action not found|  | | <a name=\"676\">676</a>|Relation definition not defined|  | | <a name=\"677\">677</a>|Invalid entity identifier for relation|  | | <a name=\"681\">681</a>|Sorting by specified field not supported|One or more of the provided fields to order by were either invalid or not supported. | | <a name=\"682\">682</a>|Too many fields to sort by|The number of fields to sort the data by exceeds the number allowed by the endpoint | | <a name=\"684\">684</a>|Sequence Not Found|  | | <a name=\"685\">685</a>|Sequence Already Exists|  | | <a name=\"686\">686</a>|Non-cycling sequence has been exhausted|  | | <a name=\"687\">687</a>|Legal Entity Identifier Already In Use|  | | <a name=\"688\">688</a>|Legal Entity Not Found|  | | <a name=\"689\">689</a>|The supplied pagination token is invalid|  | | <a name=\"690\">690</a>|Property Type Is Not Supported|  | | <a name=\"691\">691</a>|Multiple Tax-lots For Currency Type Is Not Supported|  | | <a name=\"692\">692</a>|This endpoint does not support impersonation|  | | <a name=\"693\">693</a>|Entity type is not supported for Relationship|  | | <a name=\"694\">694</a>|Relationship Validation Failure|  | | <a name=\"695\">695</a>|Relationship Not Found|  | | <a name=\"697\">697</a>|Derived Property Formula No Longer Valid|  | | <a name=\"698\">698</a>|Story is not available|  | | <a name=\"703\">703</a>|Corporate Action Does Not Exist|  | | <a name=\"720\">720</a>|The provided sort and filter combination is not valid|  | | <a name=\"721\">721</a>|A2B generation failed|  | | <a name=\"722\">722</a>|Aggregated Return Calculation Failure|  | | <a name=\"723\">723</a>|Custom Entity Definition Identifier Already In Use|  | | <a name=\"724\">724</a>|Custom Entity Definition Not Found|  | | <a name=\"725\">725</a>|The Placement requested was not found.|  | | <a name=\"726\">726</a>|The Execution requested was not found.|  | | <a name=\"727\">727</a>|The Block requested was not found.|  | | <a name=\"728\">728</a>|The Participation requested was not found.|  | | <a name=\"729\">729</a>|The Package requested was not found.|  | | <a name=\"730\">730</a>|The OrderInstruction requested was not found.|  | | <a name=\"732\">732</a>|Custom Entity not found.|  | | <a name=\"733\">733</a>|Custom Entity Identifier already in use.|  | | <a name=\"735\">735</a>|Calculation Failed.|  | | <a name=\"736\">736</a>|An expected key on HttpResponse is missing.|  | | <a name=\"737\">737</a>|A required fee detail is missing.|  | | <a name=\"738\">738</a>|Zero rows were returned from Luminesce|  | | <a name=\"739\">739</a>|Provided Weekend Mask was invalid|  | | <a name=\"742\">742</a>|Custom Entity fields do not match the definition|  | | <a name=\"746\">746</a>|The provided sequence is not valid.|  | | <a name=\"751\">751</a>|The type of the Custom Entity is different than the type provided in the definition.|  | | <a name=\"752\">752</a>|Luminesce process returned an error.|  | | <a name=\"753\">753</a>|File name or content incompatible with operation.|  | | <a name=\"755\">755</a>|Schema of response from Drive is not as expected.|  | | <a name=\"757\">757</a>|Schema of response from Luminesce is not as expected.|  | | <a name=\"758\">758</a>|Luminesce timed out.|  | | <a name=\"763\">763</a>|Invalid Lusid Entity Identifier Unit|  | | <a name=\"768\">768</a>|Fee rule not found.|  | | <a name=\"769\">769</a>|Cannot update the base currency of a portfolio with transactions loaded|  | | <a name=\"771\">771</a>|Transaction configuration source not found|  | | <a name=\"774\">774</a>|Compliance rule not found.|  | | <a name=\"775\">775</a>|Fund accounting document cannot be processed.|  | | <a name=\"778\">778</a>|Unable to look up FX rate from trade ccy to portfolio ccy for some of the trades.|  | | <a name=\"782\">782</a>|The Property definition dataType is not matching the derivation formula dataType|  | | <a name=\"783\">783</a>|The Property definition domain is not supported for derived properties|  | | <a name=\"788\">788</a>|Compliance run not found failure.|  | | <a name=\"790\">790</a>|Custom Entity has missing or invalid identifiers|  | | <a name=\"791\">791</a>|Custom Entity definition already exists|  | | <a name=\"792\">792</a>|Compliance PropertyKey is missing.|  | | <a name=\"793\">793</a>|Compliance Criteria Value for matching is missing.|  | | <a name=\"795\">795</a>|Cannot delete identifier definition|  | | <a name=\"796\">796</a>|Tax rule set not found.|  | | <a name=\"797\">797</a>|A tax rule set with this id already exists.|  | | <a name=\"798\">798</a>|Multiple rule sets for the same property key are applicable.|  | | <a name=\"800\">800</a>|Can not upsert an instrument event of this type.|  | | <a name=\"801\">801</a>|The instrument event does not exist.|  | | <a name=\"802\">802</a>|The Instrument event is missing salient information.|  | | <a name=\"803\">803</a>|The Instrument event could not be processed.|  | | <a name=\"804\">804</a>|Some data requested does not follow the order graph assumptions.|  | | <a name=\"805\">805</a>|The instrument event type does not exist.|  | | <a name=\"806\">806</a>|The transaction template specification does not exist.|  | | <a name=\"811\">811</a>|A price could not be found for an order.|  | | <a name=\"812\">812</a>|A price could not be found for an allocation.|  | | <a name=\"813\">813</a>|Chart of Accounts not found.|  | | <a name=\"814\">814</a>|Account not found.|  | | <a name=\"815\">815</a>|Abor not found.|  | | <a name=\"816\">816</a>|Abor Configuration not found.|  | | <a name=\"817\">817</a>|Reconciliation mapping not found|  | | <a name=\"818\">818</a>|Attribute type could not be deleted because it doesn't exist.|  | | <a name=\"819\">819</a>|Reconciliation not found.|  | | <a name=\"820\">820</a>|Custodian Account not found.|  | | <a name=\"821\">821</a>|Allocation Failure|  | | <a name=\"822\">822</a>|Reconciliation run not found|  | | <a name=\"823\">823</a>|Reconciliation break not found|  | | <a name=\"824\">824</a>|Entity link type could not be deleted because it doesn't exist.|  | | <a name=\"828\">828</a>|Address key definition not found.|  | | <a name=\"829\">829</a>|Compliance template not found.|  | | <a name=\"830\">830</a>|Action not supported|  | | <a name=\"831\">831</a>|Reference list not found.|  | | <a name=\"832\">832</a>|Posting Module not found.|  | | <a name=\"833\">833</a>|The type of parameter provided did not match that required by the compliance rule.|  | | <a name=\"834\">834</a>|The parameters provided by a rule did not match those required by its template.|  | | <a name=\"835\">835</a>|PostingModuleRule has a not allowed Property Domain.|  | | <a name=\"836\">836</a>|Structured result data not found.|  | | <a name=\"837\">837</a>|Diary entry not found.|  | | <a name=\"838\">838</a>|Diary entry could not be created.|  | | <a name=\"839\">839</a>|Diary entry already exists.|  | | <a name=\"861\">861</a>|Compliance run summary not found.|  | | <a name=\"869\">869</a>|Conflicting instrument properties in batch.|  | | <a name=\"870\">870</a>|Compliance run summary already exists.|  | | <a name=\"871\">871</a>|The specified impersonated user does not exist|  | | <a name=\"874\">874</a>|Provided Property Domain is not supported for entity filter.|  | | <a name=\"875\">875</a>|Cannot Delete System Reference List.|  | 
 *
 * The version of the OpenAPI document: 1.1.158
 * Contact: info@finbourne.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Lusid.Sdk.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IReconciliationsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// [EXPERIMENTAL] CreateScheduledReconciliation: Create a scheduled reconciliation
        /// </summary>
        /// <remarks>
        /// Create a scheduled reconciliation for the given request
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation</param>
        /// <param name="createReconciliationRequest">The definition of the reconciliation (optional)</param>
        /// <returns>Reconciliation</returns>
        Reconciliation CreateScheduledReconciliation(string scope, CreateReconciliationRequest createReconciliationRequest = default(CreateReconciliationRequest));

        /// <summary>
        /// [EXPERIMENTAL] CreateScheduledReconciliation: Create a scheduled reconciliation
        /// </summary>
        /// <remarks>
        /// Create a scheduled reconciliation for the given request
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation</param>
        /// <param name="createReconciliationRequest">The definition of the reconciliation (optional)</param>
        /// <returns>ApiResponse of Reconciliation</returns>
        ApiResponse<Reconciliation> CreateScheduledReconciliationWithHttpInfo(string scope, CreateReconciliationRequest createReconciliationRequest = default(CreateReconciliationRequest));
        /// <summary>
        /// [EXPERIMENTAL] DeleteReconciliation: Delete scheduled reconciliation
        /// </summary>
        /// <remarks>
        /// Delete the given scheduled reconciliation
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the scheduled reconciliation</param>
        /// <param name="code">The code of the scheduled reconciliation</param>
        /// <returns>DeletedEntityResponse</returns>
        DeletedEntityResponse DeleteReconciliation(string scope, string code);

        /// <summary>
        /// [EXPERIMENTAL] DeleteReconciliation: Delete scheduled reconciliation
        /// </summary>
        /// <remarks>
        /// Delete the given scheduled reconciliation
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the scheduled reconciliation</param>
        /// <param name="code">The code of the scheduled reconciliation</param>
        /// <returns>ApiResponse of DeletedEntityResponse</returns>
        ApiResponse<DeletedEntityResponse> DeleteReconciliationWithHttpInfo(string scope, string code);
        /// <summary>
        /// [EXPERIMENTAL] DeleteReconciliationBreak: Delete reconciliation break
        /// </summary>
        /// <remarks>
        /// Delete the given reconciliation break
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="breakId">The unique identifier for the break</param>
        /// <returns>DeletedEntityResponse</returns>
        DeletedEntityResponse DeleteReconciliationBreak(string scope, string code, DateTimeOffset runDate, int version, string breakId);

        /// <summary>
        /// [EXPERIMENTAL] DeleteReconciliationBreak: Delete reconciliation break
        /// </summary>
        /// <remarks>
        /// Delete the given reconciliation break
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="breakId">The unique identifier for the break</param>
        /// <returns>ApiResponse of DeletedEntityResponse</returns>
        ApiResponse<DeletedEntityResponse> DeleteReconciliationBreakWithHttpInfo(string scope, string code, DateTimeOffset runDate, int version, string breakId);
        /// <summary>
        /// [EARLY ACCESS] DeleteReconciliationMapping: Delete a mapping
        /// </summary>
        /// <remarks>
        /// Deletes the mapping identified by the scope and code
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the mapping.</param>
        /// <param name="code">The code fof the mapping.</param>
        /// <returns>string</returns>
        string DeleteReconciliationMapping(string scope, string code);

        /// <summary>
        /// [EARLY ACCESS] DeleteReconciliationMapping: Delete a mapping
        /// </summary>
        /// <remarks>
        /// Deletes the mapping identified by the scope and code
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the mapping.</param>
        /// <param name="code">The code fof the mapping.</param>
        /// <returns>ApiResponse of string</returns>
        ApiResponse<string> DeleteReconciliationMappingWithHttpInfo(string scope, string code);
        /// <summary>
        /// [EXPERIMENTAL] DeleteReconciliationRun: Delete reconciliation run
        /// </summary>
        /// <remarks>
        /// Delete the given reconciliation run
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the run</param>
        /// <param name="code">The code of the reconciliation associated with the run</param>
        /// <param name="runDate">The date of the reconciliation run</param>
        /// <param name="version">The version number of the reconciliation run</param>
        /// <returns>DeletedEntityResponse</returns>
        DeletedEntityResponse DeleteReconciliationRun(string scope, string code, DateTimeOffset runDate, int version);

        /// <summary>
        /// [EXPERIMENTAL] DeleteReconciliationRun: Delete reconciliation run
        /// </summary>
        /// <remarks>
        /// Delete the given reconciliation run
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the run</param>
        /// <param name="code">The code of the reconciliation associated with the run</param>
        /// <param name="runDate">The date of the reconciliation run</param>
        /// <param name="version">The version number of the reconciliation run</param>
        /// <returns>ApiResponse of DeletedEntityResponse</returns>
        ApiResponse<DeletedEntityResponse> DeleteReconciliationRunWithHttpInfo(string scope, string code, DateTimeOffset runDate, int version);
        /// <summary>
        /// [EXPERIMENTAL] GetReconciliation: Get scheduled reconciliation
        /// </summary>
        /// <remarks>
        /// Get the requested scheduled reconciliation
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the scheduled reconciliation</param>
        /// <param name="code">The code of the scheduled reconciliation</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the scheduled reconciliation. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the scheduled reconciliation. Defaults to returning the latest version of the reconciliation if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Reconciliation&#39; property domain to decorate onto the reconciliation.              These must take the form {domain}/{scope}/{code}, for example &#39;Reconciliation/Broker/Id&#39;. (optional)</param>
        /// <returns>Reconciliation</returns>
        Reconciliation GetReconciliation(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>));

        /// <summary>
        /// [EXPERIMENTAL] GetReconciliation: Get scheduled reconciliation
        /// </summary>
        /// <remarks>
        /// Get the requested scheduled reconciliation
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the scheduled reconciliation</param>
        /// <param name="code">The code of the scheduled reconciliation</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the scheduled reconciliation. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the scheduled reconciliation. Defaults to returning the latest version of the reconciliation if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Reconciliation&#39; property domain to decorate onto the reconciliation.              These must take the form {domain}/{scope}/{code}, for example &#39;Reconciliation/Broker/Id&#39;. (optional)</param>
        /// <returns>ApiResponse of Reconciliation</returns>
        ApiResponse<Reconciliation> GetReconciliationWithHttpInfo(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>));
        /// <summary>
        /// [EXPERIMENTAL] GetReconciliationBreak: Get reconciliation break
        /// </summary>
        /// <remarks>
        /// Get the requested reconciliation break
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="breakId">The unique identifier for the break</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the reconciliation break. Defaults to returning the latest version of the reconciliation break if not specified. (optional)</param>
        /// <returns>ReconciliationRunBreak</returns>
        ReconciliationRunBreak GetReconciliationBreak(string scope, string code, DateTimeOffset runDate, int version, string breakId, DateTimeOffset? asAt = default(DateTimeOffset?));

        /// <summary>
        /// [EXPERIMENTAL] GetReconciliationBreak: Get reconciliation break
        /// </summary>
        /// <remarks>
        /// Get the requested reconciliation break
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="breakId">The unique identifier for the break</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the reconciliation break. Defaults to returning the latest version of the reconciliation break if not specified. (optional)</param>
        /// <returns>ApiResponse of ReconciliationRunBreak</returns>
        ApiResponse<ReconciliationRunBreak> GetReconciliationBreakWithHttpInfo(string scope, string code, DateTimeOffset runDate, int version, string breakId, DateTimeOffset? asAt = default(DateTimeOffset?));
        /// <summary>
        /// [EARLY ACCESS] GetReconciliationMapping: Get a mapping
        /// </summary>
        /// <remarks>
        /// Gets a mapping identified by the given scope and code
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the mapping.</param>
        /// <param name="code">The code of the mapping.</param>
        /// <returns>Mapping</returns>
        Mapping GetReconciliationMapping(string scope, string code);

        /// <summary>
        /// [EARLY ACCESS] GetReconciliationMapping: Get a mapping
        /// </summary>
        /// <remarks>
        /// Gets a mapping identified by the given scope and code
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the mapping.</param>
        /// <param name="code">The code of the mapping.</param>
        /// <returns>ApiResponse of Mapping</returns>
        ApiResponse<Mapping> GetReconciliationMappingWithHttpInfo(string scope, string code);
        /// <summary>
        /// [EXPERIMENTAL] GetReconciliationRun: Get a reconciliation run
        /// </summary>
        /// <remarks>
        /// Get the requested reconciliation run
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the run</param>
        /// <param name="code">The code of the reconciliation associated with the run</param>
        /// <param name="runDate">The date of the run</param>
        /// <param name="version">The version number of the run</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the reconciliation run. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the reconciliation run. Defaults to returning the latest version of the reconciliation run if not specified. (optional)</param>
        /// <returns>ReconciliationRun</returns>
        ReconciliationRun GetReconciliationRun(string scope, string code, DateTimeOffset runDate, int version, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?));

        /// <summary>
        /// [EXPERIMENTAL] GetReconciliationRun: Get a reconciliation run
        /// </summary>
        /// <remarks>
        /// Get the requested reconciliation run
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the run</param>
        /// <param name="code">The code of the reconciliation associated with the run</param>
        /// <param name="runDate">The date of the run</param>
        /// <param name="version">The version number of the run</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the reconciliation run. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the reconciliation run. Defaults to returning the latest version of the reconciliation run if not specified. (optional)</param>
        /// <returns>ApiResponse of ReconciliationRun</returns>
        ApiResponse<ReconciliationRun> GetReconciliationRunWithHttpInfo(string scope, string code, DateTimeOffset runDate, int version, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?));
        /// <summary>
        /// [EXPERIMENTAL] ListReconciliationBreaks: List reconciliation breaks
        /// </summary>
        /// <remarks>
        /// List all reconciliation breaks associated with a given run
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the reconciliation runs. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the reconciliation runs. Defaults to returning the latest version              of each run if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing reconciliation runs; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. Also, if set, a start value cannot be provided. (optional)</param>
        /// <param name="start">When paginating, skip this number of results. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results. (optional)</param>
        /// <returns>PagedResourceListOfReconciliationRunBreak</returns>
        PagedResourceListOfReconciliationRunBreak ListReconciliationBreaks(string scope, string code, DateTimeOffset runDate, int version, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? start = default(int?), int? limit = default(int?), string filter = default(string));

        /// <summary>
        /// [EXPERIMENTAL] ListReconciliationBreaks: List reconciliation breaks
        /// </summary>
        /// <remarks>
        /// List all reconciliation breaks associated with a given run
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the reconciliation runs. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the reconciliation runs. Defaults to returning the latest version              of each run if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing reconciliation runs; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. Also, if set, a start value cannot be provided. (optional)</param>
        /// <param name="start">When paginating, skip this number of results. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results. (optional)</param>
        /// <returns>ApiResponse of PagedResourceListOfReconciliationRunBreak</returns>
        ApiResponse<PagedResourceListOfReconciliationRunBreak> ListReconciliationBreaksWithHttpInfo(string scope, string code, DateTimeOffset runDate, int version, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? start = default(int?), int? limit = default(int?), string filter = default(string));
        /// <summary>
        /// [EARLY ACCESS] ListReconciliationMappings: List the reconciliation mappings
        /// </summary>
        /// <remarks>
        /// Lists all mappings this user is entitled to see
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="reconciliationType">Optional parameter to specify which type of mappings should be returned.  Defaults to Transaction if not provided. (optional)</param>
        /// <returns>ResourceListOfMapping</returns>
        ResourceListOfMapping ListReconciliationMappings(string reconciliationType = default(string));

        /// <summary>
        /// [EARLY ACCESS] ListReconciliationMappings: List the reconciliation mappings
        /// </summary>
        /// <remarks>
        /// Lists all mappings this user is entitled to see
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="reconciliationType">Optional parameter to specify which type of mappings should be returned.  Defaults to Transaction if not provided. (optional)</param>
        /// <returns>ApiResponse of ResourceListOfMapping</returns>
        ApiResponse<ResourceListOfMapping> ListReconciliationMappingsWithHttpInfo(string reconciliationType = default(string));
        /// <summary>
        /// [EXPERIMENTAL] ListReconciliationRuns: List Reconciliation runs
        /// </summary>
        /// <remarks>
        /// List all runs for a given reconciliation
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation</param>
        /// <param name="code">The code of the reconciliation</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the reconciliation runs. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the reconciliation runs. Defaults to returning the latest version              of each run if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing reconciliation runs; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. Also, if set, a start value cannot be provided. (optional)</param>
        /// <param name="start">When paginating, skip this number of results. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the run date, specify \&quot;Date eq 10/03/2018\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <returns>PagedResourceListOfReconciliationRun</returns>
        PagedResourceListOfReconciliationRun ListReconciliationRuns(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? start = default(int?), int? limit = default(int?), string filter = default(string));

        /// <summary>
        /// [EXPERIMENTAL] ListReconciliationRuns: List Reconciliation runs
        /// </summary>
        /// <remarks>
        /// List all runs for a given reconciliation
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation</param>
        /// <param name="code">The code of the reconciliation</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the reconciliation runs. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the reconciliation runs. Defaults to returning the latest version              of each run if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing reconciliation runs; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. Also, if set, a start value cannot be provided. (optional)</param>
        /// <param name="start">When paginating, skip this number of results. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the run date, specify \&quot;Date eq 10/03/2018\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <returns>ApiResponse of PagedResourceListOfReconciliationRun</returns>
        ApiResponse<PagedResourceListOfReconciliationRun> ListReconciliationRunsWithHttpInfo(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? start = default(int?), int? limit = default(int?), string filter = default(string));
        /// <summary>
        /// [EXPERIMENTAL] ListReconciliations: List scheduled reconciliations
        /// </summary>
        /// <remarks>
        /// List all the scheduled reconciliations matching particular criteria
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the reconciliation. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the reconciliation. Defaults to returning the latest version              of each reconciliation if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing reconciliations; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. Also, if set, a start value cannot be provided. (optional)</param>
        /// <param name="start">When paginating, skip this number of results. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the reconciliation type, specify \&quot;id.Code eq &#39;001&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Reconciliation&#39; domain to decorate onto each reconciliation.              These must take the format {domain}/{scope}/{code}, for example &#39;Reconciliation/Broker/Id&#39;. (optional)</param>
        /// <returns>PagedResourceListOfReconciliation</returns>
        PagedResourceListOfReconciliation ListReconciliations(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? start = default(int?), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>));

        /// <summary>
        /// [EXPERIMENTAL] ListReconciliations: List scheduled reconciliations
        /// </summary>
        /// <remarks>
        /// List all the scheduled reconciliations matching particular criteria
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the reconciliation. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the reconciliation. Defaults to returning the latest version              of each reconciliation if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing reconciliations; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. Also, if set, a start value cannot be provided. (optional)</param>
        /// <param name="start">When paginating, skip this number of results. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the reconciliation type, specify \&quot;id.Code eq &#39;001&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Reconciliation&#39; domain to decorate onto each reconciliation.              These must take the format {domain}/{scope}/{code}, for example &#39;Reconciliation/Broker/Id&#39;. (optional)</param>
        /// <returns>ApiResponse of PagedResourceListOfReconciliation</returns>
        ApiResponse<PagedResourceListOfReconciliation> ListReconciliationsWithHttpInfo(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? start = default(int?), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>));
        /// <summary>
        /// ReconcileGeneric: Reconcile either holdings or valuations performed on one or two sets of holdings using one or two configuration recipes.                The output is configurable for various types of comparisons, to allow tolerances on numerical and date-time data or case-insensitivity on strings,  and elision of resulting differences where they are &#39;empty&#39; or null or zero.
        /// </summary>
        /// <remarks>
        /// Perform evaluation of one or two set of holdings (a portfolio of instruments) using one or two (potentially different) configuration recipes.  Produce a breakdown of the resulting differences in evaluation that can be iterated through.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="reconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <returns>ReconciliationResponse</returns>
        ReconciliationResponse ReconcileGeneric(ReconciliationRequest reconciliationRequest = default(ReconciliationRequest));

        /// <summary>
        /// ReconcileGeneric: Reconcile either holdings or valuations performed on one or two sets of holdings using one or two configuration recipes.                The output is configurable for various types of comparisons, to allow tolerances on numerical and date-time data or case-insensitivity on strings,  and elision of resulting differences where they are &#39;empty&#39; or null or zero.
        /// </summary>
        /// <remarks>
        /// Perform evaluation of one or two set of holdings (a portfolio of instruments) using one or two (potentially different) configuration recipes.  Produce a breakdown of the resulting differences in evaluation that can be iterated through.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="reconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <returns>ApiResponse of ReconciliationResponse</returns>
        ApiResponse<ReconciliationResponse> ReconcileGenericWithHttpInfo(ReconciliationRequest reconciliationRequest = default(ReconciliationRequest));
        /// <summary>
        /// [EARLY ACCESS] ReconcileHoldings: Reconcile portfolio holdings
        /// </summary>
        /// <remarks>
        /// Reconcile the holdings of two portfolios.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sortBy">Optional. Order the results by these fields. Use use the &#39;-&#39; sign to denote descending order e.g. -MyFieldName (optional)</param>
        /// <param name="start">Optional. When paginating, skip this number of results (optional)</param>
        /// <param name="limit">Optional. When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Optional. Expression to filter the result set.              For example, to filter on the left portfolio Code, use \&quot;left.portfolioId.code eq &#39;string&#39;\&quot;              Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <param name="portfoliosReconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <returns>ResourceListOfReconciliationBreak</returns>
        ResourceListOfReconciliationBreak ReconcileHoldings(List<string> sortBy = default(List<string>), int? start = default(int?), int? limit = default(int?), string filter = default(string), PortfoliosReconciliationRequest portfoliosReconciliationRequest = default(PortfoliosReconciliationRequest));

        /// <summary>
        /// [EARLY ACCESS] ReconcileHoldings: Reconcile portfolio holdings
        /// </summary>
        /// <remarks>
        /// Reconcile the holdings of two portfolios.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sortBy">Optional. Order the results by these fields. Use use the &#39;-&#39; sign to denote descending order e.g. -MyFieldName (optional)</param>
        /// <param name="start">Optional. When paginating, skip this number of results (optional)</param>
        /// <param name="limit">Optional. When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Optional. Expression to filter the result set.              For example, to filter on the left portfolio Code, use \&quot;left.portfolioId.code eq &#39;string&#39;\&quot;              Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <param name="portfoliosReconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <returns>ApiResponse of ResourceListOfReconciliationBreak</returns>
        ApiResponse<ResourceListOfReconciliationBreak> ReconcileHoldingsWithHttpInfo(List<string> sortBy = default(List<string>), int? start = default(int?), int? limit = default(int?), string filter = default(string), PortfoliosReconciliationRequest portfoliosReconciliationRequest = default(PortfoliosReconciliationRequest));
        /// <summary>
        /// ReconcileInline: Reconcile valuations performed on one or two sets of inline instruments using one or two configuration recipes.
        /// </summary>
        /// <remarks>
        /// Perform valuation of one or two set of inline instruments using different one or two configuration recipes. Produce a breakdown of the resulting differences in valuation.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="inlineValuationsReconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <returns>ListAggregationReconciliation</returns>
        ListAggregationReconciliation ReconcileInline(InlineValuationsReconciliationRequest inlineValuationsReconciliationRequest = default(InlineValuationsReconciliationRequest));

        /// <summary>
        /// ReconcileInline: Reconcile valuations performed on one or two sets of inline instruments using one or two configuration recipes.
        /// </summary>
        /// <remarks>
        /// Perform valuation of one or two set of inline instruments using different one or two configuration recipes. Produce a breakdown of the resulting differences in valuation.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="inlineValuationsReconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <returns>ApiResponse of ListAggregationReconciliation</returns>
        ApiResponse<ListAggregationReconciliation> ReconcileInlineWithHttpInfo(InlineValuationsReconciliationRequest inlineValuationsReconciliationRequest = default(InlineValuationsReconciliationRequest));
        /// <summary>
        /// [EARLY ACCESS] ReconcileTransactions: Perform a Transactions Reconciliation.
        /// </summary>
        /// <remarks>
        /// Evaluates two sets of transactions to determine which transactions from each set likely match  using the rules of a specified mapping.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="transactionReconciliationRequest"> (optional)</param>
        /// <returns>TransactionsReconciliationsResponse</returns>
        TransactionsReconciliationsResponse ReconcileTransactions(TransactionReconciliationRequest transactionReconciliationRequest = default(TransactionReconciliationRequest));

        /// <summary>
        /// [EARLY ACCESS] ReconcileTransactions: Perform a Transactions Reconciliation.
        /// </summary>
        /// <remarks>
        /// Evaluates two sets of transactions to determine which transactions from each set likely match  using the rules of a specified mapping.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="transactionReconciliationRequest"> (optional)</param>
        /// <returns>ApiResponse of TransactionsReconciliationsResponse</returns>
        ApiResponse<TransactionsReconciliationsResponse> ReconcileTransactionsWithHttpInfo(TransactionReconciliationRequest transactionReconciliationRequest = default(TransactionReconciliationRequest));
        /// <summary>
        /// [EXPERIMENTAL] ReconcileTransactionsV2: Perform a Transactions Reconciliation.
        /// </summary>
        /// <remarks>
        /// Evaluates two sets of transactions to determine which transactions from each set likely match  using the rules of a specified mapping.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="transactionReconciliationRequestV2"> (optional)</param>
        /// <returns>ReconciliationResponse</returns>
        ReconciliationResponse ReconcileTransactionsV2(TransactionReconciliationRequestV2 transactionReconciliationRequestV2 = default(TransactionReconciliationRequestV2));

        /// <summary>
        /// [EXPERIMENTAL] ReconcileTransactionsV2: Perform a Transactions Reconciliation.
        /// </summary>
        /// <remarks>
        /// Evaluates two sets of transactions to determine which transactions from each set likely match  using the rules of a specified mapping.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="transactionReconciliationRequestV2"> (optional)</param>
        /// <returns>ApiResponse of ReconciliationResponse</returns>
        ApiResponse<ReconciliationResponse> ReconcileTransactionsV2WithHttpInfo(TransactionReconciliationRequestV2 transactionReconciliationRequestV2 = default(TransactionReconciliationRequestV2));
        /// <summary>
        /// ReconcileValuation: Reconcile valuations performed on one or two sets of holdings using one or two configuration recipes.
        /// </summary>
        /// <remarks>
        /// Perform valuation of one or two set of holdings using different one or two configuration recipes. Produce a breakdown of the resulting differences in valuation.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="valuationsReconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <returns>ListAggregationReconciliation</returns>
        ListAggregationReconciliation ReconcileValuation(ValuationsReconciliationRequest valuationsReconciliationRequest = default(ValuationsReconciliationRequest));

        /// <summary>
        /// ReconcileValuation: Reconcile valuations performed on one or two sets of holdings using one or two configuration recipes.
        /// </summary>
        /// <remarks>
        /// Perform valuation of one or two set of holdings using different one or two configuration recipes. Produce a breakdown of the resulting differences in valuation.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="valuationsReconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <returns>ApiResponse of ListAggregationReconciliation</returns>
        ApiResponse<ListAggregationReconciliation> ReconcileValuationWithHttpInfo(ValuationsReconciliationRequest valuationsReconciliationRequest = default(ValuationsReconciliationRequest));
        /// <summary>
        /// [EXPERIMENTAL] UpdateReconciliation: Update scheduled reconciliation
        /// </summary>
        /// <remarks>
        /// Update a given scheduled reconciliation
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation to be updated</param>
        /// <param name="code">The code of the reconciliation to be updated</param>
        /// <param name="updateReconciliationRequest">The updated definition of the reconciliation (optional)</param>
        /// <returns>Reconciliation</returns>
        Reconciliation UpdateReconciliation(string scope, string code, UpdateReconciliationRequest updateReconciliationRequest = default(UpdateReconciliationRequest));

        /// <summary>
        /// [EXPERIMENTAL] UpdateReconciliation: Update scheduled reconciliation
        /// </summary>
        /// <remarks>
        /// Update a given scheduled reconciliation
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation to be updated</param>
        /// <param name="code">The code of the reconciliation to be updated</param>
        /// <param name="updateReconciliationRequest">The updated definition of the reconciliation (optional)</param>
        /// <returns>ApiResponse of Reconciliation</returns>
        ApiResponse<Reconciliation> UpdateReconciliationWithHttpInfo(string scope, string code, UpdateReconciliationRequest updateReconciliationRequest = default(UpdateReconciliationRequest));
        /// <summary>
        /// [EXPERIMENTAL] UpsertReconciliationBreak: Upsert a reconciliation break
        /// </summary>
        /// <remarks>
        /// Update or create a given reconciliation break
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="upsertReconciliationBreakRequest">The definition of the reconciliation break request (optional)</param>
        /// <returns>ReconciliationRunBreak</returns>
        ReconciliationRunBreak UpsertReconciliationBreak(string scope, string code, DateTimeOffset runDate, int version, UpsertReconciliationBreakRequest upsertReconciliationBreakRequest = default(UpsertReconciliationBreakRequest));

        /// <summary>
        /// [EXPERIMENTAL] UpsertReconciliationBreak: Upsert a reconciliation break
        /// </summary>
        /// <remarks>
        /// Update or create a given reconciliation break
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="upsertReconciliationBreakRequest">The definition of the reconciliation break request (optional)</param>
        /// <returns>ApiResponse of ReconciliationRunBreak</returns>
        ApiResponse<ReconciliationRunBreak> UpsertReconciliationBreakWithHttpInfo(string scope, string code, DateTimeOffset runDate, int version, UpsertReconciliationBreakRequest upsertReconciliationBreakRequest = default(UpsertReconciliationBreakRequest));
        /// <summary>
        /// [EARLY ACCESS] UpsertReconciliationMapping: Create or update a mapping
        /// </summary>
        /// <remarks>
        /// If no mapping exists with the specified scope and code will create a new one.  Else will update the existing mapping
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mapping">The mapping to be created / updated. (optional)</param>
        /// <returns>Mapping</returns>
        Mapping UpsertReconciliationMapping(Mapping mapping = default(Mapping));

        /// <summary>
        /// [EARLY ACCESS] UpsertReconciliationMapping: Create or update a mapping
        /// </summary>
        /// <remarks>
        /// If no mapping exists with the specified scope and code will create a new one.  Else will update the existing mapping
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mapping">The mapping to be created / updated. (optional)</param>
        /// <returns>ApiResponse of Mapping</returns>
        ApiResponse<Mapping> UpsertReconciliationMappingWithHttpInfo(Mapping mapping = default(Mapping));
        /// <summary>
        /// [EXPERIMENTAL] UpsertReconciliationRun: Update or Create a reconciliation run
        /// </summary>
        /// <remarks>
        /// Existing reconciliations will be updated, non-existing ones will be created
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the run</param>
        /// <param name="code">The code of the reconciliation associated with the run</param>
        /// <param name="upsertReconciliationRunRequest">The definition of the reconciliation run (optional)</param>
        /// <returns>ReconciliationRun</returns>
        ReconciliationRun UpsertReconciliationRun(string scope, string code, UpsertReconciliationRunRequest upsertReconciliationRunRequest = default(UpsertReconciliationRunRequest));

        /// <summary>
        /// [EXPERIMENTAL] UpsertReconciliationRun: Update or Create a reconciliation run
        /// </summary>
        /// <remarks>
        /// Existing reconciliations will be updated, non-existing ones will be created
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the run</param>
        /// <param name="code">The code of the reconciliation associated with the run</param>
        /// <param name="upsertReconciliationRunRequest">The definition of the reconciliation run (optional)</param>
        /// <returns>ApiResponse of ReconciliationRun</returns>
        ApiResponse<ReconciliationRun> UpsertReconciliationRunWithHttpInfo(string scope, string code, UpsertReconciliationRunRequest upsertReconciliationRunRequest = default(UpsertReconciliationRunRequest));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IReconciliationsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// [EXPERIMENTAL] CreateScheduledReconciliation: Create a scheduled reconciliation
        /// </summary>
        /// <remarks>
        /// Create a scheduled reconciliation for the given request
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation</param>
        /// <param name="createReconciliationRequest">The definition of the reconciliation (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Reconciliation</returns>
        System.Threading.Tasks.Task<Reconciliation> CreateScheduledReconciliationAsync(string scope, CreateReconciliationRequest createReconciliationRequest = default(CreateReconciliationRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] CreateScheduledReconciliation: Create a scheduled reconciliation
        /// </summary>
        /// <remarks>
        /// Create a scheduled reconciliation for the given request
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation</param>
        /// <param name="createReconciliationRequest">The definition of the reconciliation (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Reconciliation)</returns>
        System.Threading.Tasks.Task<ApiResponse<Reconciliation>> CreateScheduledReconciliationWithHttpInfoAsync(string scope, CreateReconciliationRequest createReconciliationRequest = default(CreateReconciliationRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] DeleteReconciliation: Delete scheduled reconciliation
        /// </summary>
        /// <remarks>
        /// Delete the given scheduled reconciliation
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the scheduled reconciliation</param>
        /// <param name="code">The code of the scheduled reconciliation</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DeletedEntityResponse</returns>
        System.Threading.Tasks.Task<DeletedEntityResponse> DeleteReconciliationAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] DeleteReconciliation: Delete scheduled reconciliation
        /// </summary>
        /// <remarks>
        /// Delete the given scheduled reconciliation
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the scheduled reconciliation</param>
        /// <param name="code">The code of the scheduled reconciliation</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DeletedEntityResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<DeletedEntityResponse>> DeleteReconciliationWithHttpInfoAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] DeleteReconciliationBreak: Delete reconciliation break
        /// </summary>
        /// <remarks>
        /// Delete the given reconciliation break
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="breakId">The unique identifier for the break</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DeletedEntityResponse</returns>
        System.Threading.Tasks.Task<DeletedEntityResponse> DeleteReconciliationBreakAsync(string scope, string code, DateTimeOffset runDate, int version, string breakId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] DeleteReconciliationBreak: Delete reconciliation break
        /// </summary>
        /// <remarks>
        /// Delete the given reconciliation break
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="breakId">The unique identifier for the break</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DeletedEntityResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<DeletedEntityResponse>> DeleteReconciliationBreakWithHttpInfoAsync(string scope, string code, DateTimeOffset runDate, int version, string breakId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EARLY ACCESS] DeleteReconciliationMapping: Delete a mapping
        /// </summary>
        /// <remarks>
        /// Deletes the mapping identified by the scope and code
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the mapping.</param>
        /// <param name="code">The code fof the mapping.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of string</returns>
        System.Threading.Tasks.Task<string> DeleteReconciliationMappingAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EARLY ACCESS] DeleteReconciliationMapping: Delete a mapping
        /// </summary>
        /// <remarks>
        /// Deletes the mapping identified by the scope and code
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the mapping.</param>
        /// <param name="code">The code fof the mapping.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (string)</returns>
        System.Threading.Tasks.Task<ApiResponse<string>> DeleteReconciliationMappingWithHttpInfoAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] DeleteReconciliationRun: Delete reconciliation run
        /// </summary>
        /// <remarks>
        /// Delete the given reconciliation run
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the run</param>
        /// <param name="code">The code of the reconciliation associated with the run</param>
        /// <param name="runDate">The date of the reconciliation run</param>
        /// <param name="version">The version number of the reconciliation run</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DeletedEntityResponse</returns>
        System.Threading.Tasks.Task<DeletedEntityResponse> DeleteReconciliationRunAsync(string scope, string code, DateTimeOffset runDate, int version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] DeleteReconciliationRun: Delete reconciliation run
        /// </summary>
        /// <remarks>
        /// Delete the given reconciliation run
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the run</param>
        /// <param name="code">The code of the reconciliation associated with the run</param>
        /// <param name="runDate">The date of the reconciliation run</param>
        /// <param name="version">The version number of the reconciliation run</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DeletedEntityResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<DeletedEntityResponse>> DeleteReconciliationRunWithHttpInfoAsync(string scope, string code, DateTimeOffset runDate, int version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] GetReconciliation: Get scheduled reconciliation
        /// </summary>
        /// <remarks>
        /// Get the requested scheduled reconciliation
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the scheduled reconciliation</param>
        /// <param name="code">The code of the scheduled reconciliation</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the scheduled reconciliation. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the scheduled reconciliation. Defaults to returning the latest version of the reconciliation if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Reconciliation&#39; property domain to decorate onto the reconciliation.              These must take the form {domain}/{scope}/{code}, for example &#39;Reconciliation/Broker/Id&#39;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Reconciliation</returns>
        System.Threading.Tasks.Task<Reconciliation> GetReconciliationAsync(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] GetReconciliation: Get scheduled reconciliation
        /// </summary>
        /// <remarks>
        /// Get the requested scheduled reconciliation
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the scheduled reconciliation</param>
        /// <param name="code">The code of the scheduled reconciliation</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the scheduled reconciliation. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the scheduled reconciliation. Defaults to returning the latest version of the reconciliation if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Reconciliation&#39; property domain to decorate onto the reconciliation.              These must take the form {domain}/{scope}/{code}, for example &#39;Reconciliation/Broker/Id&#39;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Reconciliation)</returns>
        System.Threading.Tasks.Task<ApiResponse<Reconciliation>> GetReconciliationWithHttpInfoAsync(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] GetReconciliationBreak: Get reconciliation break
        /// </summary>
        /// <remarks>
        /// Get the requested reconciliation break
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="breakId">The unique identifier for the break</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the reconciliation break. Defaults to returning the latest version of the reconciliation break if not specified. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ReconciliationRunBreak</returns>
        System.Threading.Tasks.Task<ReconciliationRunBreak> GetReconciliationBreakAsync(string scope, string code, DateTimeOffset runDate, int version, string breakId, DateTimeOffset? asAt = default(DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] GetReconciliationBreak: Get reconciliation break
        /// </summary>
        /// <remarks>
        /// Get the requested reconciliation break
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="breakId">The unique identifier for the break</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the reconciliation break. Defaults to returning the latest version of the reconciliation break if not specified. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ReconciliationRunBreak)</returns>
        System.Threading.Tasks.Task<ApiResponse<ReconciliationRunBreak>> GetReconciliationBreakWithHttpInfoAsync(string scope, string code, DateTimeOffset runDate, int version, string breakId, DateTimeOffset? asAt = default(DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EARLY ACCESS] GetReconciliationMapping: Get a mapping
        /// </summary>
        /// <remarks>
        /// Gets a mapping identified by the given scope and code
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the mapping.</param>
        /// <param name="code">The code of the mapping.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Mapping</returns>
        System.Threading.Tasks.Task<Mapping> GetReconciliationMappingAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EARLY ACCESS] GetReconciliationMapping: Get a mapping
        /// </summary>
        /// <remarks>
        /// Gets a mapping identified by the given scope and code
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the mapping.</param>
        /// <param name="code">The code of the mapping.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Mapping)</returns>
        System.Threading.Tasks.Task<ApiResponse<Mapping>> GetReconciliationMappingWithHttpInfoAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] GetReconciliationRun: Get a reconciliation run
        /// </summary>
        /// <remarks>
        /// Get the requested reconciliation run
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the run</param>
        /// <param name="code">The code of the reconciliation associated with the run</param>
        /// <param name="runDate">The date of the run</param>
        /// <param name="version">The version number of the run</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the reconciliation run. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the reconciliation run. Defaults to returning the latest version of the reconciliation run if not specified. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ReconciliationRun</returns>
        System.Threading.Tasks.Task<ReconciliationRun> GetReconciliationRunAsync(string scope, string code, DateTimeOffset runDate, int version, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] GetReconciliationRun: Get a reconciliation run
        /// </summary>
        /// <remarks>
        /// Get the requested reconciliation run
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the run</param>
        /// <param name="code">The code of the reconciliation associated with the run</param>
        /// <param name="runDate">The date of the run</param>
        /// <param name="version">The version number of the run</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the reconciliation run. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the reconciliation run. Defaults to returning the latest version of the reconciliation run if not specified. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ReconciliationRun)</returns>
        System.Threading.Tasks.Task<ApiResponse<ReconciliationRun>> GetReconciliationRunWithHttpInfoAsync(string scope, string code, DateTimeOffset runDate, int version, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] ListReconciliationBreaks: List reconciliation breaks
        /// </summary>
        /// <remarks>
        /// List all reconciliation breaks associated with a given run
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the reconciliation runs. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the reconciliation runs. Defaults to returning the latest version              of each run if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing reconciliation runs; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. Also, if set, a start value cannot be provided. (optional)</param>
        /// <param name="start">When paginating, skip this number of results. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PagedResourceListOfReconciliationRunBreak</returns>
        System.Threading.Tasks.Task<PagedResourceListOfReconciliationRunBreak> ListReconciliationBreaksAsync(string scope, string code, DateTimeOffset runDate, int version, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? start = default(int?), int? limit = default(int?), string filter = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] ListReconciliationBreaks: List reconciliation breaks
        /// </summary>
        /// <remarks>
        /// List all reconciliation breaks associated with a given run
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the reconciliation runs. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the reconciliation runs. Defaults to returning the latest version              of each run if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing reconciliation runs; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. Also, if set, a start value cannot be provided. (optional)</param>
        /// <param name="start">When paginating, skip this number of results. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PagedResourceListOfReconciliationRunBreak)</returns>
        System.Threading.Tasks.Task<ApiResponse<PagedResourceListOfReconciliationRunBreak>> ListReconciliationBreaksWithHttpInfoAsync(string scope, string code, DateTimeOffset runDate, int version, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? start = default(int?), int? limit = default(int?), string filter = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EARLY ACCESS] ListReconciliationMappings: List the reconciliation mappings
        /// </summary>
        /// <remarks>
        /// Lists all mappings this user is entitled to see
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="reconciliationType">Optional parameter to specify which type of mappings should be returned.  Defaults to Transaction if not provided. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ResourceListOfMapping</returns>
        System.Threading.Tasks.Task<ResourceListOfMapping> ListReconciliationMappingsAsync(string reconciliationType = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EARLY ACCESS] ListReconciliationMappings: List the reconciliation mappings
        /// </summary>
        /// <remarks>
        /// Lists all mappings this user is entitled to see
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="reconciliationType">Optional parameter to specify which type of mappings should be returned.  Defaults to Transaction if not provided. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ResourceListOfMapping)</returns>
        System.Threading.Tasks.Task<ApiResponse<ResourceListOfMapping>> ListReconciliationMappingsWithHttpInfoAsync(string reconciliationType = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] ListReconciliationRuns: List Reconciliation runs
        /// </summary>
        /// <remarks>
        /// List all runs for a given reconciliation
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation</param>
        /// <param name="code">The code of the reconciliation</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the reconciliation runs. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the reconciliation runs. Defaults to returning the latest version              of each run if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing reconciliation runs; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. Also, if set, a start value cannot be provided. (optional)</param>
        /// <param name="start">When paginating, skip this number of results. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the run date, specify \&quot;Date eq 10/03/2018\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PagedResourceListOfReconciliationRun</returns>
        System.Threading.Tasks.Task<PagedResourceListOfReconciliationRun> ListReconciliationRunsAsync(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? start = default(int?), int? limit = default(int?), string filter = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] ListReconciliationRuns: List Reconciliation runs
        /// </summary>
        /// <remarks>
        /// List all runs for a given reconciliation
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation</param>
        /// <param name="code">The code of the reconciliation</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the reconciliation runs. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the reconciliation runs. Defaults to returning the latest version              of each run if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing reconciliation runs; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. Also, if set, a start value cannot be provided. (optional)</param>
        /// <param name="start">When paginating, skip this number of results. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the run date, specify \&quot;Date eq 10/03/2018\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PagedResourceListOfReconciliationRun)</returns>
        System.Threading.Tasks.Task<ApiResponse<PagedResourceListOfReconciliationRun>> ListReconciliationRunsWithHttpInfoAsync(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? start = default(int?), int? limit = default(int?), string filter = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] ListReconciliations: List scheduled reconciliations
        /// </summary>
        /// <remarks>
        /// List all the scheduled reconciliations matching particular criteria
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the reconciliation. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the reconciliation. Defaults to returning the latest version              of each reconciliation if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing reconciliations; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. Also, if set, a start value cannot be provided. (optional)</param>
        /// <param name="start">When paginating, skip this number of results. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the reconciliation type, specify \&quot;id.Code eq &#39;001&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Reconciliation&#39; domain to decorate onto each reconciliation.              These must take the format {domain}/{scope}/{code}, for example &#39;Reconciliation/Broker/Id&#39;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PagedResourceListOfReconciliation</returns>
        System.Threading.Tasks.Task<PagedResourceListOfReconciliation> ListReconciliationsAsync(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? start = default(int?), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] ListReconciliations: List scheduled reconciliations
        /// </summary>
        /// <remarks>
        /// List all the scheduled reconciliations matching particular criteria
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the reconciliation. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the reconciliation. Defaults to returning the latest version              of each reconciliation if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing reconciliations; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. Also, if set, a start value cannot be provided. (optional)</param>
        /// <param name="start">When paginating, skip this number of results. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the reconciliation type, specify \&quot;id.Code eq &#39;001&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Reconciliation&#39; domain to decorate onto each reconciliation.              These must take the format {domain}/{scope}/{code}, for example &#39;Reconciliation/Broker/Id&#39;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PagedResourceListOfReconciliation)</returns>
        System.Threading.Tasks.Task<ApiResponse<PagedResourceListOfReconciliation>> ListReconciliationsWithHttpInfoAsync(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? start = default(int?), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// ReconcileGeneric: Reconcile either holdings or valuations performed on one or two sets of holdings using one or two configuration recipes.                The output is configurable for various types of comparisons, to allow tolerances on numerical and date-time data or case-insensitivity on strings,  and elision of resulting differences where they are &#39;empty&#39; or null or zero.
        /// </summary>
        /// <remarks>
        /// Perform evaluation of one or two set of holdings (a portfolio of instruments) using one or two (potentially different) configuration recipes.  Produce a breakdown of the resulting differences in evaluation that can be iterated through.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="reconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ReconciliationResponse</returns>
        System.Threading.Tasks.Task<ReconciliationResponse> ReconcileGenericAsync(ReconciliationRequest reconciliationRequest = default(ReconciliationRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// ReconcileGeneric: Reconcile either holdings or valuations performed on one or two sets of holdings using one or two configuration recipes.                The output is configurable for various types of comparisons, to allow tolerances on numerical and date-time data or case-insensitivity on strings,  and elision of resulting differences where they are &#39;empty&#39; or null or zero.
        /// </summary>
        /// <remarks>
        /// Perform evaluation of one or two set of holdings (a portfolio of instruments) using one or two (potentially different) configuration recipes.  Produce a breakdown of the resulting differences in evaluation that can be iterated through.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="reconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ReconciliationResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<ReconciliationResponse>> ReconcileGenericWithHttpInfoAsync(ReconciliationRequest reconciliationRequest = default(ReconciliationRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EARLY ACCESS] ReconcileHoldings: Reconcile portfolio holdings
        /// </summary>
        /// <remarks>
        /// Reconcile the holdings of two portfolios.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sortBy">Optional. Order the results by these fields. Use use the &#39;-&#39; sign to denote descending order e.g. -MyFieldName (optional)</param>
        /// <param name="start">Optional. When paginating, skip this number of results (optional)</param>
        /// <param name="limit">Optional. When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Optional. Expression to filter the result set.              For example, to filter on the left portfolio Code, use \&quot;left.portfolioId.code eq &#39;string&#39;\&quot;              Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <param name="portfoliosReconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ResourceListOfReconciliationBreak</returns>
        System.Threading.Tasks.Task<ResourceListOfReconciliationBreak> ReconcileHoldingsAsync(List<string> sortBy = default(List<string>), int? start = default(int?), int? limit = default(int?), string filter = default(string), PortfoliosReconciliationRequest portfoliosReconciliationRequest = default(PortfoliosReconciliationRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EARLY ACCESS] ReconcileHoldings: Reconcile portfolio holdings
        /// </summary>
        /// <remarks>
        /// Reconcile the holdings of two portfolios.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sortBy">Optional. Order the results by these fields. Use use the &#39;-&#39; sign to denote descending order e.g. -MyFieldName (optional)</param>
        /// <param name="start">Optional. When paginating, skip this number of results (optional)</param>
        /// <param name="limit">Optional. When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Optional. Expression to filter the result set.              For example, to filter on the left portfolio Code, use \&quot;left.portfolioId.code eq &#39;string&#39;\&quot;              Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <param name="portfoliosReconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ResourceListOfReconciliationBreak)</returns>
        System.Threading.Tasks.Task<ApiResponse<ResourceListOfReconciliationBreak>> ReconcileHoldingsWithHttpInfoAsync(List<string> sortBy = default(List<string>), int? start = default(int?), int? limit = default(int?), string filter = default(string), PortfoliosReconciliationRequest portfoliosReconciliationRequest = default(PortfoliosReconciliationRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// ReconcileInline: Reconcile valuations performed on one or two sets of inline instruments using one or two configuration recipes.
        /// </summary>
        /// <remarks>
        /// Perform valuation of one or two set of inline instruments using different one or two configuration recipes. Produce a breakdown of the resulting differences in valuation.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="inlineValuationsReconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ListAggregationReconciliation</returns>
        System.Threading.Tasks.Task<ListAggregationReconciliation> ReconcileInlineAsync(InlineValuationsReconciliationRequest inlineValuationsReconciliationRequest = default(InlineValuationsReconciliationRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// ReconcileInline: Reconcile valuations performed on one or two sets of inline instruments using one or two configuration recipes.
        /// </summary>
        /// <remarks>
        /// Perform valuation of one or two set of inline instruments using different one or two configuration recipes. Produce a breakdown of the resulting differences in valuation.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="inlineValuationsReconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ListAggregationReconciliation)</returns>
        System.Threading.Tasks.Task<ApiResponse<ListAggregationReconciliation>> ReconcileInlineWithHttpInfoAsync(InlineValuationsReconciliationRequest inlineValuationsReconciliationRequest = default(InlineValuationsReconciliationRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EARLY ACCESS] ReconcileTransactions: Perform a Transactions Reconciliation.
        /// </summary>
        /// <remarks>
        /// Evaluates two sets of transactions to determine which transactions from each set likely match  using the rules of a specified mapping.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="transactionReconciliationRequest"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TransactionsReconciliationsResponse</returns>
        System.Threading.Tasks.Task<TransactionsReconciliationsResponse> ReconcileTransactionsAsync(TransactionReconciliationRequest transactionReconciliationRequest = default(TransactionReconciliationRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EARLY ACCESS] ReconcileTransactions: Perform a Transactions Reconciliation.
        /// </summary>
        /// <remarks>
        /// Evaluates two sets of transactions to determine which transactions from each set likely match  using the rules of a specified mapping.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="transactionReconciliationRequest"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TransactionsReconciliationsResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<TransactionsReconciliationsResponse>> ReconcileTransactionsWithHttpInfoAsync(TransactionReconciliationRequest transactionReconciliationRequest = default(TransactionReconciliationRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] ReconcileTransactionsV2: Perform a Transactions Reconciliation.
        /// </summary>
        /// <remarks>
        /// Evaluates two sets of transactions to determine which transactions from each set likely match  using the rules of a specified mapping.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="transactionReconciliationRequestV2"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ReconciliationResponse</returns>
        System.Threading.Tasks.Task<ReconciliationResponse> ReconcileTransactionsV2Async(TransactionReconciliationRequestV2 transactionReconciliationRequestV2 = default(TransactionReconciliationRequestV2), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] ReconcileTransactionsV2: Perform a Transactions Reconciliation.
        /// </summary>
        /// <remarks>
        /// Evaluates two sets of transactions to determine which transactions from each set likely match  using the rules of a specified mapping.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="transactionReconciliationRequestV2"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ReconciliationResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<ReconciliationResponse>> ReconcileTransactionsV2WithHttpInfoAsync(TransactionReconciliationRequestV2 transactionReconciliationRequestV2 = default(TransactionReconciliationRequestV2), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// ReconcileValuation: Reconcile valuations performed on one or two sets of holdings using one or two configuration recipes.
        /// </summary>
        /// <remarks>
        /// Perform valuation of one or two set of holdings using different one or two configuration recipes. Produce a breakdown of the resulting differences in valuation.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="valuationsReconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ListAggregationReconciliation</returns>
        System.Threading.Tasks.Task<ListAggregationReconciliation> ReconcileValuationAsync(ValuationsReconciliationRequest valuationsReconciliationRequest = default(ValuationsReconciliationRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// ReconcileValuation: Reconcile valuations performed on one or two sets of holdings using one or two configuration recipes.
        /// </summary>
        /// <remarks>
        /// Perform valuation of one or two set of holdings using different one or two configuration recipes. Produce a breakdown of the resulting differences in valuation.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="valuationsReconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ListAggregationReconciliation)</returns>
        System.Threading.Tasks.Task<ApiResponse<ListAggregationReconciliation>> ReconcileValuationWithHttpInfoAsync(ValuationsReconciliationRequest valuationsReconciliationRequest = default(ValuationsReconciliationRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] UpdateReconciliation: Update scheduled reconciliation
        /// </summary>
        /// <remarks>
        /// Update a given scheduled reconciliation
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation to be updated</param>
        /// <param name="code">The code of the reconciliation to be updated</param>
        /// <param name="updateReconciliationRequest">The updated definition of the reconciliation (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Reconciliation</returns>
        System.Threading.Tasks.Task<Reconciliation> UpdateReconciliationAsync(string scope, string code, UpdateReconciliationRequest updateReconciliationRequest = default(UpdateReconciliationRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] UpdateReconciliation: Update scheduled reconciliation
        /// </summary>
        /// <remarks>
        /// Update a given scheduled reconciliation
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation to be updated</param>
        /// <param name="code">The code of the reconciliation to be updated</param>
        /// <param name="updateReconciliationRequest">The updated definition of the reconciliation (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Reconciliation)</returns>
        System.Threading.Tasks.Task<ApiResponse<Reconciliation>> UpdateReconciliationWithHttpInfoAsync(string scope, string code, UpdateReconciliationRequest updateReconciliationRequest = default(UpdateReconciliationRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] UpsertReconciliationBreak: Upsert a reconciliation break
        /// </summary>
        /// <remarks>
        /// Update or create a given reconciliation break
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="upsertReconciliationBreakRequest">The definition of the reconciliation break request (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ReconciliationRunBreak</returns>
        System.Threading.Tasks.Task<ReconciliationRunBreak> UpsertReconciliationBreakAsync(string scope, string code, DateTimeOffset runDate, int version, UpsertReconciliationBreakRequest upsertReconciliationBreakRequest = default(UpsertReconciliationBreakRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] UpsertReconciliationBreak: Upsert a reconciliation break
        /// </summary>
        /// <remarks>
        /// Update or create a given reconciliation break
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="upsertReconciliationBreakRequest">The definition of the reconciliation break request (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ReconciliationRunBreak)</returns>
        System.Threading.Tasks.Task<ApiResponse<ReconciliationRunBreak>> UpsertReconciliationBreakWithHttpInfoAsync(string scope, string code, DateTimeOffset runDate, int version, UpsertReconciliationBreakRequest upsertReconciliationBreakRequest = default(UpsertReconciliationBreakRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EARLY ACCESS] UpsertReconciliationMapping: Create or update a mapping
        /// </summary>
        /// <remarks>
        /// If no mapping exists with the specified scope and code will create a new one.  Else will update the existing mapping
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mapping">The mapping to be created / updated. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Mapping</returns>
        System.Threading.Tasks.Task<Mapping> UpsertReconciliationMappingAsync(Mapping mapping = default(Mapping), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EARLY ACCESS] UpsertReconciliationMapping: Create or update a mapping
        /// </summary>
        /// <remarks>
        /// If no mapping exists with the specified scope and code will create a new one.  Else will update the existing mapping
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mapping">The mapping to be created / updated. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Mapping)</returns>
        System.Threading.Tasks.Task<ApiResponse<Mapping>> UpsertReconciliationMappingWithHttpInfoAsync(Mapping mapping = default(Mapping), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] UpsertReconciliationRun: Update or Create a reconciliation run
        /// </summary>
        /// <remarks>
        /// Existing reconciliations will be updated, non-existing ones will be created
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the run</param>
        /// <param name="code">The code of the reconciliation associated with the run</param>
        /// <param name="upsertReconciliationRunRequest">The definition of the reconciliation run (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ReconciliationRun</returns>
        System.Threading.Tasks.Task<ReconciliationRun> UpsertReconciliationRunAsync(string scope, string code, UpsertReconciliationRunRequest upsertReconciliationRunRequest = default(UpsertReconciliationRunRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] UpsertReconciliationRun: Update or Create a reconciliation run
        /// </summary>
        /// <remarks>
        /// Existing reconciliations will be updated, non-existing ones will be created
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the run</param>
        /// <param name="code">The code of the reconciliation associated with the run</param>
        /// <param name="upsertReconciliationRunRequest">The definition of the reconciliation run (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ReconciliationRun)</returns>
        System.Threading.Tasks.Task<ApiResponse<ReconciliationRun>> UpsertReconciliationRunWithHttpInfoAsync(string scope, string code, UpsertReconciliationRunRequest upsertReconciliationRunRequest = default(UpsertReconciliationRunRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IReconciliationsApi : IReconciliationsApiSync, IReconciliationsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ReconciliationsApi : IReconciliationsApi
    {
        private Lusid.Sdk.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReconciliationsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ReconciliationsApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReconciliationsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ReconciliationsApi(String basePath)
        {
            this.Configuration = Lusid.Sdk.Client.Configuration.MergeConfigurations(
                Lusid.Sdk.Client.GlobalConfiguration.Instance,
                new Lusid.Sdk.Client.Configuration { BasePath = basePath }
            );
            this.Client = new Lusid.Sdk.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Lusid.Sdk.Client.ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = Lusid.Sdk.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReconciliationsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ReconciliationsApi(Lusid.Sdk.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = configuration;
            this.Client = new Lusid.Sdk.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Lusid.Sdk.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = Lusid.Sdk.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReconciliationsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public ReconciliationsApi(Lusid.Sdk.Client.ISynchronousClient client, Lusid.Sdk.Client.IAsynchronousClient asyncClient, Lusid.Sdk.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = Lusid.Sdk.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public Lusid.Sdk.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public Lusid.Sdk.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Lusid.Sdk.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public Lusid.Sdk.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// [EXPERIMENTAL] CreateScheduledReconciliation: Create a scheduled reconciliation Create a scheduled reconciliation for the given request
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation</param>
        /// <param name="createReconciliationRequest">The definition of the reconciliation (optional)</param>
        /// <returns>Reconciliation</returns>
        public Reconciliation CreateScheduledReconciliation(string scope, CreateReconciliationRequest createReconciliationRequest = default(CreateReconciliationRequest))
        {
            Lusid.Sdk.Client.ApiResponse<Reconciliation> localVarResponse = CreateScheduledReconciliationWithHttpInfo(scope, createReconciliationRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] CreateScheduledReconciliation: Create a scheduled reconciliation Create a scheduled reconciliation for the given request
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation</param>
        /// <param name="createReconciliationRequest">The definition of the reconciliation (optional)</param>
        /// <returns>ApiResponse of Reconciliation</returns>
        public Lusid.Sdk.Client.ApiResponse<Reconciliation> CreateScheduledReconciliationWithHttpInfo(string scope, CreateReconciliationRequest createReconciliationRequest = default(CreateReconciliationRequest))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ReconciliationsApi->CreateScheduledReconciliation");

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json",
                "application/json",
                "text/json",
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.Data = createReconciliationRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request
            var localVarResponse = this.Client.Post<Reconciliation>("/api/portfolios/$scheduledReconciliations/{scope}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateScheduledReconciliation", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] CreateScheduledReconciliation: Create a scheduled reconciliation Create a scheduled reconciliation for the given request
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation</param>
        /// <param name="createReconciliationRequest">The definition of the reconciliation (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Reconciliation</returns>
        public async System.Threading.Tasks.Task<Reconciliation> CreateScheduledReconciliationAsync(string scope, CreateReconciliationRequest createReconciliationRequest = default(CreateReconciliationRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<Reconciliation> localVarResponse = await CreateScheduledReconciliationWithHttpInfoAsync(scope, createReconciliationRequest, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] CreateScheduledReconciliation: Create a scheduled reconciliation Create a scheduled reconciliation for the given request
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation</param>
        /// <param name="createReconciliationRequest">The definition of the reconciliation (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Reconciliation)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<Reconciliation>> CreateScheduledReconciliationWithHttpInfoAsync(string scope, CreateReconciliationRequest createReconciliationRequest = default(CreateReconciliationRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ReconciliationsApi->CreateScheduledReconciliation");


            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json", 
                "application/json", 
                "text/json", 
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.Data = createReconciliationRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<Reconciliation>("/api/portfolios/$scheduledReconciliations/{scope}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateScheduledReconciliation", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteReconciliation: Delete scheduled reconciliation Delete the given scheduled reconciliation
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the scheduled reconciliation</param>
        /// <param name="code">The code of the scheduled reconciliation</param>
        /// <returns>DeletedEntityResponse</returns>
        public DeletedEntityResponse DeleteReconciliation(string scope, string code)
        {
            Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse> localVarResponse = DeleteReconciliationWithHttpInfo(scope, code);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteReconciliation: Delete scheduled reconciliation Delete the given scheduled reconciliation
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the scheduled reconciliation</param>
        /// <param name="code">The code of the scheduled reconciliation</param>
        /// <returns>ApiResponse of DeletedEntityResponse</returns>
        public Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse> DeleteReconciliationWithHttpInfo(string scope, string code)
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ReconciliationsApi->DeleteReconciliation");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ReconciliationsApi->DeleteReconciliation");

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request
            var localVarResponse = this.Client.Delete<DeletedEntityResponse>("/api/portfolios/$scheduledReconciliations/{scope}/{code}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteReconciliation", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteReconciliation: Delete scheduled reconciliation Delete the given scheduled reconciliation
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the scheduled reconciliation</param>
        /// <param name="code">The code of the scheduled reconciliation</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DeletedEntityResponse</returns>
        public async System.Threading.Tasks.Task<DeletedEntityResponse> DeleteReconciliationAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse> localVarResponse = await DeleteReconciliationWithHttpInfoAsync(scope, code, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteReconciliation: Delete scheduled reconciliation Delete the given scheduled reconciliation
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the scheduled reconciliation</param>
        /// <param name="code">The code of the scheduled reconciliation</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DeletedEntityResponse)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse>> DeleteReconciliationWithHttpInfoAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ReconciliationsApi->DeleteReconciliation");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ReconciliationsApi->DeleteReconciliation");


            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<DeletedEntityResponse>("/api/portfolios/$scheduledReconciliations/{scope}/{code}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteReconciliation", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteReconciliationBreak: Delete reconciliation break Delete the given reconciliation break
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="breakId">The unique identifier for the break</param>
        /// <returns>DeletedEntityResponse</returns>
        public DeletedEntityResponse DeleteReconciliationBreak(string scope, string code, DateTimeOffset runDate, int version, string breakId)
        {
            Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse> localVarResponse = DeleteReconciliationBreakWithHttpInfo(scope, code, runDate, version, breakId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteReconciliationBreak: Delete reconciliation break Delete the given reconciliation break
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="breakId">The unique identifier for the break</param>
        /// <returns>ApiResponse of DeletedEntityResponse</returns>
        public Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse> DeleteReconciliationBreakWithHttpInfo(string scope, string code, DateTimeOffset runDate, int version, string breakId)
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ReconciliationsApi->DeleteReconciliationBreak");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ReconciliationsApi->DeleteReconciliationBreak");

            // verify the required parameter 'breakId' is set
            if (breakId == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'breakId' when calling ReconciliationsApi->DeleteReconciliationBreak");

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter
            localVarRequestOptions.PathParameters.Add("runDate", Lusid.Sdk.Client.ClientUtils.ParameterToString(runDate)); // path parameter
            localVarRequestOptions.PathParameters.Add("version", Lusid.Sdk.Client.ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.PathParameters.Add("breakId", Lusid.Sdk.Client.ClientUtils.ParameterToString(breakId)); // path parameter

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request
            var localVarResponse = this.Client.Delete<DeletedEntityResponse>("/api/portfolios/$scheduledReconciliations/{scope}/{code}/runs/{runDate}/{version}/breaks/{breakId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteReconciliationBreak", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteReconciliationBreak: Delete reconciliation break Delete the given reconciliation break
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="breakId">The unique identifier for the break</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DeletedEntityResponse</returns>
        public async System.Threading.Tasks.Task<DeletedEntityResponse> DeleteReconciliationBreakAsync(string scope, string code, DateTimeOffset runDate, int version, string breakId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse> localVarResponse = await DeleteReconciliationBreakWithHttpInfoAsync(scope, code, runDate, version, breakId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteReconciliationBreak: Delete reconciliation break Delete the given reconciliation break
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="breakId">The unique identifier for the break</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DeletedEntityResponse)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse>> DeleteReconciliationBreakWithHttpInfoAsync(string scope, string code, DateTimeOffset runDate, int version, string breakId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ReconciliationsApi->DeleteReconciliationBreak");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ReconciliationsApi->DeleteReconciliationBreak");

            // verify the required parameter 'breakId' is set
            if (breakId == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'breakId' when calling ReconciliationsApi->DeleteReconciliationBreak");


            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter
            localVarRequestOptions.PathParameters.Add("runDate", Lusid.Sdk.Client.ClientUtils.ParameterToString(runDate)); // path parameter
            localVarRequestOptions.PathParameters.Add("version", Lusid.Sdk.Client.ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.PathParameters.Add("breakId", Lusid.Sdk.Client.ClientUtils.ParameterToString(breakId)); // path parameter

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<DeletedEntityResponse>("/api/portfolios/$scheduledReconciliations/{scope}/{code}/runs/{runDate}/{version}/breaks/{breakId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteReconciliationBreak", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] DeleteReconciliationMapping: Delete a mapping Deletes the mapping identified by the scope and code
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the mapping.</param>
        /// <param name="code">The code fof the mapping.</param>
        /// <returns>string</returns>
        public string DeleteReconciliationMapping(string scope, string code)
        {
            Lusid.Sdk.Client.ApiResponse<string> localVarResponse = DeleteReconciliationMappingWithHttpInfo(scope, code);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] DeleteReconciliationMapping: Delete a mapping Deletes the mapping identified by the scope and code
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the mapping.</param>
        /// <param name="code">The code fof the mapping.</param>
        /// <returns>ApiResponse of string</returns>
        public Lusid.Sdk.Client.ApiResponse<string> DeleteReconciliationMappingWithHttpInfo(string scope, string code)
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ReconciliationsApi->DeleteReconciliationMapping");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ReconciliationsApi->DeleteReconciliationMapping");

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request
            var localVarResponse = this.Client.Delete<string>("/api/portfolios/mapping/{scope}/{code}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteReconciliationMapping", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] DeleteReconciliationMapping: Delete a mapping Deletes the mapping identified by the scope and code
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the mapping.</param>
        /// <param name="code">The code fof the mapping.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of string</returns>
        public async System.Threading.Tasks.Task<string> DeleteReconciliationMappingAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<string> localVarResponse = await DeleteReconciliationMappingWithHttpInfoAsync(scope, code, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] DeleteReconciliationMapping: Delete a mapping Deletes the mapping identified by the scope and code
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the mapping.</param>
        /// <param name="code">The code fof the mapping.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (string)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<string>> DeleteReconciliationMappingWithHttpInfoAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ReconciliationsApi->DeleteReconciliationMapping");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ReconciliationsApi->DeleteReconciliationMapping");


            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<string>("/api/portfolios/mapping/{scope}/{code}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteReconciliationMapping", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteReconciliationRun: Delete reconciliation run Delete the given reconciliation run
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the run</param>
        /// <param name="code">The code of the reconciliation associated with the run</param>
        /// <param name="runDate">The date of the reconciliation run</param>
        /// <param name="version">The version number of the reconciliation run</param>
        /// <returns>DeletedEntityResponse</returns>
        public DeletedEntityResponse DeleteReconciliationRun(string scope, string code, DateTimeOffset runDate, int version)
        {
            Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse> localVarResponse = DeleteReconciliationRunWithHttpInfo(scope, code, runDate, version);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteReconciliationRun: Delete reconciliation run Delete the given reconciliation run
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the run</param>
        /// <param name="code">The code of the reconciliation associated with the run</param>
        /// <param name="runDate">The date of the reconciliation run</param>
        /// <param name="version">The version number of the reconciliation run</param>
        /// <returns>ApiResponse of DeletedEntityResponse</returns>
        public Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse> DeleteReconciliationRunWithHttpInfo(string scope, string code, DateTimeOffset runDate, int version)
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ReconciliationsApi->DeleteReconciliationRun");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ReconciliationsApi->DeleteReconciliationRun");

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter
            localVarRequestOptions.PathParameters.Add("runDate", Lusid.Sdk.Client.ClientUtils.ParameterToString(runDate)); // path parameter
            localVarRequestOptions.PathParameters.Add("version", Lusid.Sdk.Client.ClientUtils.ParameterToString(version)); // path parameter

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request
            var localVarResponse = this.Client.Delete<DeletedEntityResponse>("/api/portfolios/$scheduledReconciliations/{scope}/{code}/runs/{runDate}/{version}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteReconciliationRun", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteReconciliationRun: Delete reconciliation run Delete the given reconciliation run
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the run</param>
        /// <param name="code">The code of the reconciliation associated with the run</param>
        /// <param name="runDate">The date of the reconciliation run</param>
        /// <param name="version">The version number of the reconciliation run</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DeletedEntityResponse</returns>
        public async System.Threading.Tasks.Task<DeletedEntityResponse> DeleteReconciliationRunAsync(string scope, string code, DateTimeOffset runDate, int version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse> localVarResponse = await DeleteReconciliationRunWithHttpInfoAsync(scope, code, runDate, version, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteReconciliationRun: Delete reconciliation run Delete the given reconciliation run
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the run</param>
        /// <param name="code">The code of the reconciliation associated with the run</param>
        /// <param name="runDate">The date of the reconciliation run</param>
        /// <param name="version">The version number of the reconciliation run</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DeletedEntityResponse)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse>> DeleteReconciliationRunWithHttpInfoAsync(string scope, string code, DateTimeOffset runDate, int version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ReconciliationsApi->DeleteReconciliationRun");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ReconciliationsApi->DeleteReconciliationRun");


            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter
            localVarRequestOptions.PathParameters.Add("runDate", Lusid.Sdk.Client.ClientUtils.ParameterToString(runDate)); // path parameter
            localVarRequestOptions.PathParameters.Add("version", Lusid.Sdk.Client.ClientUtils.ParameterToString(version)); // path parameter

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<DeletedEntityResponse>("/api/portfolios/$scheduledReconciliations/{scope}/{code}/runs/{runDate}/{version}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteReconciliationRun", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetReconciliation: Get scheduled reconciliation Get the requested scheduled reconciliation
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the scheduled reconciliation</param>
        /// <param name="code">The code of the scheduled reconciliation</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the scheduled reconciliation. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the scheduled reconciliation. Defaults to returning the latest version of the reconciliation if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Reconciliation&#39; property domain to decorate onto the reconciliation.              These must take the form {domain}/{scope}/{code}, for example &#39;Reconciliation/Broker/Id&#39;. (optional)</param>
        /// <returns>Reconciliation</returns>
        public Reconciliation GetReconciliation(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>))
        {
            Lusid.Sdk.Client.ApiResponse<Reconciliation> localVarResponse = GetReconciliationWithHttpInfo(scope, code, effectiveAt, asAt, propertyKeys);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetReconciliation: Get scheduled reconciliation Get the requested scheduled reconciliation
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the scheduled reconciliation</param>
        /// <param name="code">The code of the scheduled reconciliation</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the scheduled reconciliation. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the scheduled reconciliation. Defaults to returning the latest version of the reconciliation if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Reconciliation&#39; property domain to decorate onto the reconciliation.              These must take the form {domain}/{scope}/{code}, for example &#39;Reconciliation/Broker/Id&#39;. (optional)</param>
        /// <returns>ApiResponse of Reconciliation</returns>
        public Lusid.Sdk.Client.ApiResponse<Reconciliation> GetReconciliationWithHttpInfo(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ReconciliationsApi->GetReconciliation");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ReconciliationsApi->GetReconciliation");

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter
            if (effectiveAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "effectiveAt", effectiveAt));
            }
            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }
            if (propertyKeys != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("multi", "propertyKeys", propertyKeys));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request
            var localVarResponse = this.Client.Get<Reconciliation>("/api/portfolios/$scheduledReconciliations/{scope}/{code}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetReconciliation", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetReconciliation: Get scheduled reconciliation Get the requested scheduled reconciliation
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the scheduled reconciliation</param>
        /// <param name="code">The code of the scheduled reconciliation</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the scheduled reconciliation. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the scheduled reconciliation. Defaults to returning the latest version of the reconciliation if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Reconciliation&#39; property domain to decorate onto the reconciliation.              These must take the form {domain}/{scope}/{code}, for example &#39;Reconciliation/Broker/Id&#39;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Reconciliation</returns>
        public async System.Threading.Tasks.Task<Reconciliation> GetReconciliationAsync(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<Reconciliation> localVarResponse = await GetReconciliationWithHttpInfoAsync(scope, code, effectiveAt, asAt, propertyKeys, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetReconciliation: Get scheduled reconciliation Get the requested scheduled reconciliation
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the scheduled reconciliation</param>
        /// <param name="code">The code of the scheduled reconciliation</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the scheduled reconciliation. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the scheduled reconciliation. Defaults to returning the latest version of the reconciliation if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Reconciliation&#39; property domain to decorate onto the reconciliation.              These must take the form {domain}/{scope}/{code}, for example &#39;Reconciliation/Broker/Id&#39;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Reconciliation)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<Reconciliation>> GetReconciliationWithHttpInfoAsync(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ReconciliationsApi->GetReconciliation");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ReconciliationsApi->GetReconciliation");


            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter
            if (effectiveAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "effectiveAt", effectiveAt));
            }
            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }
            if (propertyKeys != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("multi", "propertyKeys", propertyKeys));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<Reconciliation>("/api/portfolios/$scheduledReconciliations/{scope}/{code}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetReconciliation", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetReconciliationBreak: Get reconciliation break Get the requested reconciliation break
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="breakId">The unique identifier for the break</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the reconciliation break. Defaults to returning the latest version of the reconciliation break if not specified. (optional)</param>
        /// <returns>ReconciliationRunBreak</returns>
        public ReconciliationRunBreak GetReconciliationBreak(string scope, string code, DateTimeOffset runDate, int version, string breakId, DateTimeOffset? asAt = default(DateTimeOffset?))
        {
            Lusid.Sdk.Client.ApiResponse<ReconciliationRunBreak> localVarResponse = GetReconciliationBreakWithHttpInfo(scope, code, runDate, version, breakId, asAt);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetReconciliationBreak: Get reconciliation break Get the requested reconciliation break
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="breakId">The unique identifier for the break</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the reconciliation break. Defaults to returning the latest version of the reconciliation break if not specified. (optional)</param>
        /// <returns>ApiResponse of ReconciliationRunBreak</returns>
        public Lusid.Sdk.Client.ApiResponse<ReconciliationRunBreak> GetReconciliationBreakWithHttpInfo(string scope, string code, DateTimeOffset runDate, int version, string breakId, DateTimeOffset? asAt = default(DateTimeOffset?))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ReconciliationsApi->GetReconciliationBreak");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ReconciliationsApi->GetReconciliationBreak");

            // verify the required parameter 'breakId' is set
            if (breakId == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'breakId' when calling ReconciliationsApi->GetReconciliationBreak");

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter
            localVarRequestOptions.PathParameters.Add("runDate", Lusid.Sdk.Client.ClientUtils.ParameterToString(runDate)); // path parameter
            localVarRequestOptions.PathParameters.Add("version", Lusid.Sdk.Client.ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.PathParameters.Add("breakId", Lusid.Sdk.Client.ClientUtils.ParameterToString(breakId)); // path parameter
            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request
            var localVarResponse = this.Client.Get<ReconciliationRunBreak>("/api/portfolios/$scheduledReconciliations/{scope}/{code}/runs/{runDate}/{version}/breaks/{breakId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetReconciliationBreak", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetReconciliationBreak: Get reconciliation break Get the requested reconciliation break
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="breakId">The unique identifier for the break</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the reconciliation break. Defaults to returning the latest version of the reconciliation break if not specified. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ReconciliationRunBreak</returns>
        public async System.Threading.Tasks.Task<ReconciliationRunBreak> GetReconciliationBreakAsync(string scope, string code, DateTimeOffset runDate, int version, string breakId, DateTimeOffset? asAt = default(DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<ReconciliationRunBreak> localVarResponse = await GetReconciliationBreakWithHttpInfoAsync(scope, code, runDate, version, breakId, asAt, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetReconciliationBreak: Get reconciliation break Get the requested reconciliation break
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="breakId">The unique identifier for the break</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the reconciliation break. Defaults to returning the latest version of the reconciliation break if not specified. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ReconciliationRunBreak)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<ReconciliationRunBreak>> GetReconciliationBreakWithHttpInfoAsync(string scope, string code, DateTimeOffset runDate, int version, string breakId, DateTimeOffset? asAt = default(DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ReconciliationsApi->GetReconciliationBreak");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ReconciliationsApi->GetReconciliationBreak");

            // verify the required parameter 'breakId' is set
            if (breakId == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'breakId' when calling ReconciliationsApi->GetReconciliationBreak");


            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter
            localVarRequestOptions.PathParameters.Add("runDate", Lusid.Sdk.Client.ClientUtils.ParameterToString(runDate)); // path parameter
            localVarRequestOptions.PathParameters.Add("version", Lusid.Sdk.Client.ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.PathParameters.Add("breakId", Lusid.Sdk.Client.ClientUtils.ParameterToString(breakId)); // path parameter
            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<ReconciliationRunBreak>("/api/portfolios/$scheduledReconciliations/{scope}/{code}/runs/{runDate}/{version}/breaks/{breakId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetReconciliationBreak", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] GetReconciliationMapping: Get a mapping Gets a mapping identified by the given scope and code
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the mapping.</param>
        /// <param name="code">The code of the mapping.</param>
        /// <returns>Mapping</returns>
        public Mapping GetReconciliationMapping(string scope, string code)
        {
            Lusid.Sdk.Client.ApiResponse<Mapping> localVarResponse = GetReconciliationMappingWithHttpInfo(scope, code);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] GetReconciliationMapping: Get a mapping Gets a mapping identified by the given scope and code
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the mapping.</param>
        /// <param name="code">The code of the mapping.</param>
        /// <returns>ApiResponse of Mapping</returns>
        public Lusid.Sdk.Client.ApiResponse<Mapping> GetReconciliationMappingWithHttpInfo(string scope, string code)
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ReconciliationsApi->GetReconciliationMapping");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ReconciliationsApi->GetReconciliationMapping");

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request
            var localVarResponse = this.Client.Get<Mapping>("/api/portfolios/mapping/{scope}/{code}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetReconciliationMapping", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] GetReconciliationMapping: Get a mapping Gets a mapping identified by the given scope and code
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the mapping.</param>
        /// <param name="code">The code of the mapping.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Mapping</returns>
        public async System.Threading.Tasks.Task<Mapping> GetReconciliationMappingAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<Mapping> localVarResponse = await GetReconciliationMappingWithHttpInfoAsync(scope, code, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] GetReconciliationMapping: Get a mapping Gets a mapping identified by the given scope and code
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the mapping.</param>
        /// <param name="code">The code of the mapping.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Mapping)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<Mapping>> GetReconciliationMappingWithHttpInfoAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ReconciliationsApi->GetReconciliationMapping");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ReconciliationsApi->GetReconciliationMapping");


            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<Mapping>("/api/portfolios/mapping/{scope}/{code}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetReconciliationMapping", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetReconciliationRun: Get a reconciliation run Get the requested reconciliation run
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the run</param>
        /// <param name="code">The code of the reconciliation associated with the run</param>
        /// <param name="runDate">The date of the run</param>
        /// <param name="version">The version number of the run</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the reconciliation run. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the reconciliation run. Defaults to returning the latest version of the reconciliation run if not specified. (optional)</param>
        /// <returns>ReconciliationRun</returns>
        public ReconciliationRun GetReconciliationRun(string scope, string code, DateTimeOffset runDate, int version, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?))
        {
            Lusid.Sdk.Client.ApiResponse<ReconciliationRun> localVarResponse = GetReconciliationRunWithHttpInfo(scope, code, runDate, version, effectiveAt, asAt);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetReconciliationRun: Get a reconciliation run Get the requested reconciliation run
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the run</param>
        /// <param name="code">The code of the reconciliation associated with the run</param>
        /// <param name="runDate">The date of the run</param>
        /// <param name="version">The version number of the run</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the reconciliation run. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the reconciliation run. Defaults to returning the latest version of the reconciliation run if not specified. (optional)</param>
        /// <returns>ApiResponse of ReconciliationRun</returns>
        public Lusid.Sdk.Client.ApiResponse<ReconciliationRun> GetReconciliationRunWithHttpInfo(string scope, string code, DateTimeOffset runDate, int version, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ReconciliationsApi->GetReconciliationRun");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ReconciliationsApi->GetReconciliationRun");

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter
            localVarRequestOptions.PathParameters.Add("runDate", Lusid.Sdk.Client.ClientUtils.ParameterToString(runDate)); // path parameter
            localVarRequestOptions.PathParameters.Add("version", Lusid.Sdk.Client.ClientUtils.ParameterToString(version)); // path parameter
            if (effectiveAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "effectiveAt", effectiveAt));
            }
            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request
            var localVarResponse = this.Client.Get<ReconciliationRun>("/api/portfolios/$scheduledReconciliations/{scope}/{code}/runs/{runDate}/{version}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetReconciliationRun", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetReconciliationRun: Get a reconciliation run Get the requested reconciliation run
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the run</param>
        /// <param name="code">The code of the reconciliation associated with the run</param>
        /// <param name="runDate">The date of the run</param>
        /// <param name="version">The version number of the run</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the reconciliation run. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the reconciliation run. Defaults to returning the latest version of the reconciliation run if not specified. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ReconciliationRun</returns>
        public async System.Threading.Tasks.Task<ReconciliationRun> GetReconciliationRunAsync(string scope, string code, DateTimeOffset runDate, int version, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<ReconciliationRun> localVarResponse = await GetReconciliationRunWithHttpInfoAsync(scope, code, runDate, version, effectiveAt, asAt, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetReconciliationRun: Get a reconciliation run Get the requested reconciliation run
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the run</param>
        /// <param name="code">The code of the reconciliation associated with the run</param>
        /// <param name="runDate">The date of the run</param>
        /// <param name="version">The version number of the run</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the reconciliation run. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the reconciliation run. Defaults to returning the latest version of the reconciliation run if not specified. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ReconciliationRun)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<ReconciliationRun>> GetReconciliationRunWithHttpInfoAsync(string scope, string code, DateTimeOffset runDate, int version, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ReconciliationsApi->GetReconciliationRun");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ReconciliationsApi->GetReconciliationRun");


            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter
            localVarRequestOptions.PathParameters.Add("runDate", Lusid.Sdk.Client.ClientUtils.ParameterToString(runDate)); // path parameter
            localVarRequestOptions.PathParameters.Add("version", Lusid.Sdk.Client.ClientUtils.ParameterToString(version)); // path parameter
            if (effectiveAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "effectiveAt", effectiveAt));
            }
            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<ReconciliationRun>("/api/portfolios/$scheduledReconciliations/{scope}/{code}/runs/{runDate}/{version}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetReconciliationRun", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListReconciliationBreaks: List reconciliation breaks List all reconciliation breaks associated with a given run
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the reconciliation runs. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the reconciliation runs. Defaults to returning the latest version              of each run if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing reconciliation runs; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. Also, if set, a start value cannot be provided. (optional)</param>
        /// <param name="start">When paginating, skip this number of results. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results. (optional)</param>
        /// <returns>PagedResourceListOfReconciliationRunBreak</returns>
        public PagedResourceListOfReconciliationRunBreak ListReconciliationBreaks(string scope, string code, DateTimeOffset runDate, int version, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? start = default(int?), int? limit = default(int?), string filter = default(string))
        {
            Lusid.Sdk.Client.ApiResponse<PagedResourceListOfReconciliationRunBreak> localVarResponse = ListReconciliationBreaksWithHttpInfo(scope, code, runDate, version, effectiveAt, asAt, page, start, limit, filter);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListReconciliationBreaks: List reconciliation breaks List all reconciliation breaks associated with a given run
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the reconciliation runs. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the reconciliation runs. Defaults to returning the latest version              of each run if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing reconciliation runs; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. Also, if set, a start value cannot be provided. (optional)</param>
        /// <param name="start">When paginating, skip this number of results. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results. (optional)</param>
        /// <returns>ApiResponse of PagedResourceListOfReconciliationRunBreak</returns>
        public Lusid.Sdk.Client.ApiResponse<PagedResourceListOfReconciliationRunBreak> ListReconciliationBreaksWithHttpInfo(string scope, string code, DateTimeOffset runDate, int version, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? start = default(int?), int? limit = default(int?), string filter = default(string))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ReconciliationsApi->ListReconciliationBreaks");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ReconciliationsApi->ListReconciliationBreaks");

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter
            localVarRequestOptions.PathParameters.Add("runDate", Lusid.Sdk.Client.ClientUtils.ParameterToString(runDate)); // path parameter
            localVarRequestOptions.PathParameters.Add("version", Lusid.Sdk.Client.ClientUtils.ParameterToString(version)); // path parameter
            if (effectiveAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "effectiveAt", effectiveAt));
            }
            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (start != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "start", start));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request
            var localVarResponse = this.Client.Get<PagedResourceListOfReconciliationRunBreak>("/api/portfolios/$scheduledReconciliations/{scope}/{code}/runs/{runDate}/{version}/breaks", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListReconciliationBreaks", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListReconciliationBreaks: List reconciliation breaks List all reconciliation breaks associated with a given run
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the reconciliation runs. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the reconciliation runs. Defaults to returning the latest version              of each run if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing reconciliation runs; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. Also, if set, a start value cannot be provided. (optional)</param>
        /// <param name="start">When paginating, skip this number of results. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PagedResourceListOfReconciliationRunBreak</returns>
        public async System.Threading.Tasks.Task<PagedResourceListOfReconciliationRunBreak> ListReconciliationBreaksAsync(string scope, string code, DateTimeOffset runDate, int version, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? start = default(int?), int? limit = default(int?), string filter = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<PagedResourceListOfReconciliationRunBreak> localVarResponse = await ListReconciliationBreaksWithHttpInfoAsync(scope, code, runDate, version, effectiveAt, asAt, page, start, limit, filter, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListReconciliationBreaks: List reconciliation breaks List all reconciliation breaks associated with a given run
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the reconciliation runs. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the reconciliation runs. Defaults to returning the latest version              of each run if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing reconciliation runs; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. Also, if set, a start value cannot be provided. (optional)</param>
        /// <param name="start">When paginating, skip this number of results. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PagedResourceListOfReconciliationRunBreak)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<PagedResourceListOfReconciliationRunBreak>> ListReconciliationBreaksWithHttpInfoAsync(string scope, string code, DateTimeOffset runDate, int version, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? start = default(int?), int? limit = default(int?), string filter = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ReconciliationsApi->ListReconciliationBreaks");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ReconciliationsApi->ListReconciliationBreaks");


            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter
            localVarRequestOptions.PathParameters.Add("runDate", Lusid.Sdk.Client.ClientUtils.ParameterToString(runDate)); // path parameter
            localVarRequestOptions.PathParameters.Add("version", Lusid.Sdk.Client.ClientUtils.ParameterToString(version)); // path parameter
            if (effectiveAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "effectiveAt", effectiveAt));
            }
            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (start != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "start", start));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<PagedResourceListOfReconciliationRunBreak>("/api/portfolios/$scheduledReconciliations/{scope}/{code}/runs/{runDate}/{version}/breaks", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListReconciliationBreaks", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] ListReconciliationMappings: List the reconciliation mappings Lists all mappings this user is entitled to see
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="reconciliationType">Optional parameter to specify which type of mappings should be returned.  Defaults to Transaction if not provided. (optional)</param>
        /// <returns>ResourceListOfMapping</returns>
        public ResourceListOfMapping ListReconciliationMappings(string reconciliationType = default(string))
        {
            Lusid.Sdk.Client.ApiResponse<ResourceListOfMapping> localVarResponse = ListReconciliationMappingsWithHttpInfo(reconciliationType);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] ListReconciliationMappings: List the reconciliation mappings Lists all mappings this user is entitled to see
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="reconciliationType">Optional parameter to specify which type of mappings should be returned.  Defaults to Transaction if not provided. (optional)</param>
        /// <returns>ApiResponse of ResourceListOfMapping</returns>
        public Lusid.Sdk.Client.ApiResponse<ResourceListOfMapping> ListReconciliationMappingsWithHttpInfo(string reconciliationType = default(string))
        {
            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (reconciliationType != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "reconciliationType", reconciliationType));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request
            var localVarResponse = this.Client.Get<ResourceListOfMapping>("/api/portfolios/mapping", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListReconciliationMappings", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] ListReconciliationMappings: List the reconciliation mappings Lists all mappings this user is entitled to see
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="reconciliationType">Optional parameter to specify which type of mappings should be returned.  Defaults to Transaction if not provided. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ResourceListOfMapping</returns>
        public async System.Threading.Tasks.Task<ResourceListOfMapping> ListReconciliationMappingsAsync(string reconciliationType = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<ResourceListOfMapping> localVarResponse = await ListReconciliationMappingsWithHttpInfoAsync(reconciliationType, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] ListReconciliationMappings: List the reconciliation mappings Lists all mappings this user is entitled to see
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="reconciliationType">Optional parameter to specify which type of mappings should be returned.  Defaults to Transaction if not provided. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ResourceListOfMapping)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<ResourceListOfMapping>> ListReconciliationMappingsWithHttpInfoAsync(string reconciliationType = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (reconciliationType != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "reconciliationType", reconciliationType));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<ResourceListOfMapping>("/api/portfolios/mapping", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListReconciliationMappings", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListReconciliationRuns: List Reconciliation runs List all runs for a given reconciliation
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation</param>
        /// <param name="code">The code of the reconciliation</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the reconciliation runs. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the reconciliation runs. Defaults to returning the latest version              of each run if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing reconciliation runs; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. Also, if set, a start value cannot be provided. (optional)</param>
        /// <param name="start">When paginating, skip this number of results. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the run date, specify \&quot;Date eq 10/03/2018\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <returns>PagedResourceListOfReconciliationRun</returns>
        public PagedResourceListOfReconciliationRun ListReconciliationRuns(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? start = default(int?), int? limit = default(int?), string filter = default(string))
        {
            Lusid.Sdk.Client.ApiResponse<PagedResourceListOfReconciliationRun> localVarResponse = ListReconciliationRunsWithHttpInfo(scope, code, effectiveAt, asAt, page, start, limit, filter);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListReconciliationRuns: List Reconciliation runs List all runs for a given reconciliation
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation</param>
        /// <param name="code">The code of the reconciliation</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the reconciliation runs. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the reconciliation runs. Defaults to returning the latest version              of each run if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing reconciliation runs; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. Also, if set, a start value cannot be provided. (optional)</param>
        /// <param name="start">When paginating, skip this number of results. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the run date, specify \&quot;Date eq 10/03/2018\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <returns>ApiResponse of PagedResourceListOfReconciliationRun</returns>
        public Lusid.Sdk.Client.ApiResponse<PagedResourceListOfReconciliationRun> ListReconciliationRunsWithHttpInfo(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? start = default(int?), int? limit = default(int?), string filter = default(string))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ReconciliationsApi->ListReconciliationRuns");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ReconciliationsApi->ListReconciliationRuns");

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter
            if (effectiveAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "effectiveAt", effectiveAt));
            }
            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (start != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "start", start));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request
            var localVarResponse = this.Client.Get<PagedResourceListOfReconciliationRun>("/api/portfolios/$scheduledReconciliations/{scope}/{code}/runs", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListReconciliationRuns", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListReconciliationRuns: List Reconciliation runs List all runs for a given reconciliation
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation</param>
        /// <param name="code">The code of the reconciliation</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the reconciliation runs. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the reconciliation runs. Defaults to returning the latest version              of each run if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing reconciliation runs; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. Also, if set, a start value cannot be provided. (optional)</param>
        /// <param name="start">When paginating, skip this number of results. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the run date, specify \&quot;Date eq 10/03/2018\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PagedResourceListOfReconciliationRun</returns>
        public async System.Threading.Tasks.Task<PagedResourceListOfReconciliationRun> ListReconciliationRunsAsync(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? start = default(int?), int? limit = default(int?), string filter = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<PagedResourceListOfReconciliationRun> localVarResponse = await ListReconciliationRunsWithHttpInfoAsync(scope, code, effectiveAt, asAt, page, start, limit, filter, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListReconciliationRuns: List Reconciliation runs List all runs for a given reconciliation
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation</param>
        /// <param name="code">The code of the reconciliation</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the reconciliation runs. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the reconciliation runs. Defaults to returning the latest version              of each run if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing reconciliation runs; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. Also, if set, a start value cannot be provided. (optional)</param>
        /// <param name="start">When paginating, skip this number of results. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the run date, specify \&quot;Date eq 10/03/2018\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PagedResourceListOfReconciliationRun)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<PagedResourceListOfReconciliationRun>> ListReconciliationRunsWithHttpInfoAsync(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? start = default(int?), int? limit = default(int?), string filter = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ReconciliationsApi->ListReconciliationRuns");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ReconciliationsApi->ListReconciliationRuns");


            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter
            if (effectiveAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "effectiveAt", effectiveAt));
            }
            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (start != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "start", start));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<PagedResourceListOfReconciliationRun>("/api/portfolios/$scheduledReconciliations/{scope}/{code}/runs", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListReconciliationRuns", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListReconciliations: List scheduled reconciliations List all the scheduled reconciliations matching particular criteria
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the reconciliation. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the reconciliation. Defaults to returning the latest version              of each reconciliation if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing reconciliations; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. Also, if set, a start value cannot be provided. (optional)</param>
        /// <param name="start">When paginating, skip this number of results. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the reconciliation type, specify \&quot;id.Code eq &#39;001&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Reconciliation&#39; domain to decorate onto each reconciliation.              These must take the format {domain}/{scope}/{code}, for example &#39;Reconciliation/Broker/Id&#39;. (optional)</param>
        /// <returns>PagedResourceListOfReconciliation</returns>
        public PagedResourceListOfReconciliation ListReconciliations(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? start = default(int?), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>))
        {
            Lusid.Sdk.Client.ApiResponse<PagedResourceListOfReconciliation> localVarResponse = ListReconciliationsWithHttpInfo(effectiveAt, asAt, page, start, limit, filter, propertyKeys);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListReconciliations: List scheduled reconciliations List all the scheduled reconciliations matching particular criteria
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the reconciliation. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the reconciliation. Defaults to returning the latest version              of each reconciliation if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing reconciliations; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. Also, if set, a start value cannot be provided. (optional)</param>
        /// <param name="start">When paginating, skip this number of results. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the reconciliation type, specify \&quot;id.Code eq &#39;001&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Reconciliation&#39; domain to decorate onto each reconciliation.              These must take the format {domain}/{scope}/{code}, for example &#39;Reconciliation/Broker/Id&#39;. (optional)</param>
        /// <returns>ApiResponse of PagedResourceListOfReconciliation</returns>
        public Lusid.Sdk.Client.ApiResponse<PagedResourceListOfReconciliation> ListReconciliationsWithHttpInfo(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? start = default(int?), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>))
        {
            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (effectiveAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "effectiveAt", effectiveAt));
            }
            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (start != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "start", start));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (propertyKeys != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("multi", "propertyKeys", propertyKeys));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request
            var localVarResponse = this.Client.Get<PagedResourceListOfReconciliation>("/api/portfolios/$scheduledReconciliations", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListReconciliations", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListReconciliations: List scheduled reconciliations List all the scheduled reconciliations matching particular criteria
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the reconciliation. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the reconciliation. Defaults to returning the latest version              of each reconciliation if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing reconciliations; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. Also, if set, a start value cannot be provided. (optional)</param>
        /// <param name="start">When paginating, skip this number of results. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the reconciliation type, specify \&quot;id.Code eq &#39;001&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Reconciliation&#39; domain to decorate onto each reconciliation.              These must take the format {domain}/{scope}/{code}, for example &#39;Reconciliation/Broker/Id&#39;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PagedResourceListOfReconciliation</returns>
        public async System.Threading.Tasks.Task<PagedResourceListOfReconciliation> ListReconciliationsAsync(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? start = default(int?), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<PagedResourceListOfReconciliation> localVarResponse = await ListReconciliationsWithHttpInfoAsync(effectiveAt, asAt, page, start, limit, filter, propertyKeys, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListReconciliations: List scheduled reconciliations List all the scheduled reconciliations matching particular criteria
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the reconciliation. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the reconciliation. Defaults to returning the latest version              of each reconciliation if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing reconciliations; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. Also, if set, a start value cannot be provided. (optional)</param>
        /// <param name="start">When paginating, skip this number of results. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the reconciliation type, specify \&quot;id.Code eq &#39;001&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Reconciliation&#39; domain to decorate onto each reconciliation.              These must take the format {domain}/{scope}/{code}, for example &#39;Reconciliation/Broker/Id&#39;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PagedResourceListOfReconciliation)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<PagedResourceListOfReconciliation>> ListReconciliationsWithHttpInfoAsync(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? start = default(int?), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (effectiveAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "effectiveAt", effectiveAt));
            }
            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (start != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "start", start));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (propertyKeys != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("multi", "propertyKeys", propertyKeys));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<PagedResourceListOfReconciliation>("/api/portfolios/$scheduledReconciliations", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListReconciliations", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// ReconcileGeneric: Reconcile either holdings or valuations performed on one or two sets of holdings using one or two configuration recipes.                The output is configurable for various types of comparisons, to allow tolerances on numerical and date-time data or case-insensitivity on strings,  and elision of resulting differences where they are &#39;empty&#39; or null or zero. Perform evaluation of one or two set of holdings (a portfolio of instruments) using one or two (potentially different) configuration recipes.  Produce a breakdown of the resulting differences in evaluation that can be iterated through.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="reconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <returns>ReconciliationResponse</returns>
        public ReconciliationResponse ReconcileGeneric(ReconciliationRequest reconciliationRequest = default(ReconciliationRequest))
        {
            Lusid.Sdk.Client.ApiResponse<ReconciliationResponse> localVarResponse = ReconcileGenericWithHttpInfo(reconciliationRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// ReconcileGeneric: Reconcile either holdings or valuations performed on one or two sets of holdings using one or two configuration recipes.                The output is configurable for various types of comparisons, to allow tolerances on numerical and date-time data or case-insensitivity on strings,  and elision of resulting differences where they are &#39;empty&#39; or null or zero. Perform evaluation of one or two set of holdings (a portfolio of instruments) using one or two (potentially different) configuration recipes.  Produce a breakdown of the resulting differences in evaluation that can be iterated through.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="reconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <returns>ApiResponse of ReconciliationResponse</returns>
        public Lusid.Sdk.Client.ApiResponse<ReconciliationResponse> ReconcileGenericWithHttpInfo(ReconciliationRequest reconciliationRequest = default(ReconciliationRequest))
        {
            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json",
                "application/json",
                "text/json",
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = reconciliationRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request
            var localVarResponse = this.Client.Post<ReconciliationResponse>("/api/portfolios/$reconcileGeneric", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ReconcileGeneric", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// ReconcileGeneric: Reconcile either holdings or valuations performed on one or two sets of holdings using one or two configuration recipes.                The output is configurable for various types of comparisons, to allow tolerances on numerical and date-time data or case-insensitivity on strings,  and elision of resulting differences where they are &#39;empty&#39; or null or zero. Perform evaluation of one or two set of holdings (a portfolio of instruments) using one or two (potentially different) configuration recipes.  Produce a breakdown of the resulting differences in evaluation that can be iterated through.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="reconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ReconciliationResponse</returns>
        public async System.Threading.Tasks.Task<ReconciliationResponse> ReconcileGenericAsync(ReconciliationRequest reconciliationRequest = default(ReconciliationRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<ReconciliationResponse> localVarResponse = await ReconcileGenericWithHttpInfoAsync(reconciliationRequest, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// ReconcileGeneric: Reconcile either holdings or valuations performed on one or two sets of holdings using one or two configuration recipes.                The output is configurable for various types of comparisons, to allow tolerances on numerical and date-time data or case-insensitivity on strings,  and elision of resulting differences where they are &#39;empty&#39; or null or zero. Perform evaluation of one or two set of holdings (a portfolio of instruments) using one or two (potentially different) configuration recipes.  Produce a breakdown of the resulting differences in evaluation that can be iterated through.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="reconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ReconciliationResponse)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<ReconciliationResponse>> ReconcileGenericWithHttpInfoAsync(ReconciliationRequest reconciliationRequest = default(ReconciliationRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json", 
                "application/json", 
                "text/json", 
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = reconciliationRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<ReconciliationResponse>("/api/portfolios/$reconcileGeneric", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ReconcileGeneric", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] ReconcileHoldings: Reconcile portfolio holdings Reconcile the holdings of two portfolios.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sortBy">Optional. Order the results by these fields. Use use the &#39;-&#39; sign to denote descending order e.g. -MyFieldName (optional)</param>
        /// <param name="start">Optional. When paginating, skip this number of results (optional)</param>
        /// <param name="limit">Optional. When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Optional. Expression to filter the result set.              For example, to filter on the left portfolio Code, use \&quot;left.portfolioId.code eq &#39;string&#39;\&quot;              Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <param name="portfoliosReconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <returns>ResourceListOfReconciliationBreak</returns>
        public ResourceListOfReconciliationBreak ReconcileHoldings(List<string> sortBy = default(List<string>), int? start = default(int?), int? limit = default(int?), string filter = default(string), PortfoliosReconciliationRequest portfoliosReconciliationRequest = default(PortfoliosReconciliationRequest))
        {
            Lusid.Sdk.Client.ApiResponse<ResourceListOfReconciliationBreak> localVarResponse = ReconcileHoldingsWithHttpInfo(sortBy, start, limit, filter, portfoliosReconciliationRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] ReconcileHoldings: Reconcile portfolio holdings Reconcile the holdings of two portfolios.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sortBy">Optional. Order the results by these fields. Use use the &#39;-&#39; sign to denote descending order e.g. -MyFieldName (optional)</param>
        /// <param name="start">Optional. When paginating, skip this number of results (optional)</param>
        /// <param name="limit">Optional. When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Optional. Expression to filter the result set.              For example, to filter on the left portfolio Code, use \&quot;left.portfolioId.code eq &#39;string&#39;\&quot;              Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <param name="portfoliosReconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <returns>ApiResponse of ResourceListOfReconciliationBreak</returns>
        public Lusid.Sdk.Client.ApiResponse<ResourceListOfReconciliationBreak> ReconcileHoldingsWithHttpInfo(List<string> sortBy = default(List<string>), int? start = default(int?), int? limit = default(int?), string filter = default(string), PortfoliosReconciliationRequest portfoliosReconciliationRequest = default(PortfoliosReconciliationRequest))
        {
            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json",
                "application/json",
                "text/json",
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (sortBy != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("multi", "sortBy", sortBy));
            }
            if (start != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "start", start));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            localVarRequestOptions.Data = portfoliosReconciliationRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request
            var localVarResponse = this.Client.Post<ResourceListOfReconciliationBreak>("/api/portfolios/$reconcileholdings", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ReconcileHoldings", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] ReconcileHoldings: Reconcile portfolio holdings Reconcile the holdings of two portfolios.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sortBy">Optional. Order the results by these fields. Use use the &#39;-&#39; sign to denote descending order e.g. -MyFieldName (optional)</param>
        /// <param name="start">Optional. When paginating, skip this number of results (optional)</param>
        /// <param name="limit">Optional. When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Optional. Expression to filter the result set.              For example, to filter on the left portfolio Code, use \&quot;left.portfolioId.code eq &#39;string&#39;\&quot;              Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <param name="portfoliosReconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ResourceListOfReconciliationBreak</returns>
        public async System.Threading.Tasks.Task<ResourceListOfReconciliationBreak> ReconcileHoldingsAsync(List<string> sortBy = default(List<string>), int? start = default(int?), int? limit = default(int?), string filter = default(string), PortfoliosReconciliationRequest portfoliosReconciliationRequest = default(PortfoliosReconciliationRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<ResourceListOfReconciliationBreak> localVarResponse = await ReconcileHoldingsWithHttpInfoAsync(sortBy, start, limit, filter, portfoliosReconciliationRequest, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] ReconcileHoldings: Reconcile portfolio holdings Reconcile the holdings of two portfolios.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sortBy">Optional. Order the results by these fields. Use use the &#39;-&#39; sign to denote descending order e.g. -MyFieldName (optional)</param>
        /// <param name="start">Optional. When paginating, skip this number of results (optional)</param>
        /// <param name="limit">Optional. When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Optional. Expression to filter the result set.              For example, to filter on the left portfolio Code, use \&quot;left.portfolioId.code eq &#39;string&#39;\&quot;              Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <param name="portfoliosReconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ResourceListOfReconciliationBreak)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<ResourceListOfReconciliationBreak>> ReconcileHoldingsWithHttpInfoAsync(List<string> sortBy = default(List<string>), int? start = default(int?), int? limit = default(int?), string filter = default(string), PortfoliosReconciliationRequest portfoliosReconciliationRequest = default(PortfoliosReconciliationRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json", 
                "application/json", 
                "text/json", 
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (sortBy != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("multi", "sortBy", sortBy));
            }
            if (start != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "start", start));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            localVarRequestOptions.Data = portfoliosReconciliationRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<ResourceListOfReconciliationBreak>("/api/portfolios/$reconcileholdings", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ReconcileHoldings", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// ReconcileInline: Reconcile valuations performed on one or two sets of inline instruments using one or two configuration recipes. Perform valuation of one or two set of inline instruments using different one or two configuration recipes. Produce a breakdown of the resulting differences in valuation.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="inlineValuationsReconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <returns>ListAggregationReconciliation</returns>
        public ListAggregationReconciliation ReconcileInline(InlineValuationsReconciliationRequest inlineValuationsReconciliationRequest = default(InlineValuationsReconciliationRequest))
        {
            Lusid.Sdk.Client.ApiResponse<ListAggregationReconciliation> localVarResponse = ReconcileInlineWithHttpInfo(inlineValuationsReconciliationRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// ReconcileInline: Reconcile valuations performed on one or two sets of inline instruments using one or two configuration recipes. Perform valuation of one or two set of inline instruments using different one or two configuration recipes. Produce a breakdown of the resulting differences in valuation.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="inlineValuationsReconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <returns>ApiResponse of ListAggregationReconciliation</returns>
        public Lusid.Sdk.Client.ApiResponse<ListAggregationReconciliation> ReconcileInlineWithHttpInfo(InlineValuationsReconciliationRequest inlineValuationsReconciliationRequest = default(InlineValuationsReconciliationRequest))
        {
            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json",
                "application/json",
                "text/json",
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = inlineValuationsReconciliationRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request
            var localVarResponse = this.Client.Post<ListAggregationReconciliation>("/api/portfolios/$reconcileInline", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ReconcileInline", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// ReconcileInline: Reconcile valuations performed on one or two sets of inline instruments using one or two configuration recipes. Perform valuation of one or two set of inline instruments using different one or two configuration recipes. Produce a breakdown of the resulting differences in valuation.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="inlineValuationsReconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ListAggregationReconciliation</returns>
        public async System.Threading.Tasks.Task<ListAggregationReconciliation> ReconcileInlineAsync(InlineValuationsReconciliationRequest inlineValuationsReconciliationRequest = default(InlineValuationsReconciliationRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<ListAggregationReconciliation> localVarResponse = await ReconcileInlineWithHttpInfoAsync(inlineValuationsReconciliationRequest, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// ReconcileInline: Reconcile valuations performed on one or two sets of inline instruments using one or two configuration recipes. Perform valuation of one or two set of inline instruments using different one or two configuration recipes. Produce a breakdown of the resulting differences in valuation.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="inlineValuationsReconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ListAggregationReconciliation)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<ListAggregationReconciliation>> ReconcileInlineWithHttpInfoAsync(InlineValuationsReconciliationRequest inlineValuationsReconciliationRequest = default(InlineValuationsReconciliationRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json", 
                "application/json", 
                "text/json", 
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = inlineValuationsReconciliationRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<ListAggregationReconciliation>("/api/portfolios/$reconcileInline", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ReconcileInline", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] ReconcileTransactions: Perform a Transactions Reconciliation. Evaluates two sets of transactions to determine which transactions from each set likely match  using the rules of a specified mapping.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="transactionReconciliationRequest"> (optional)</param>
        /// <returns>TransactionsReconciliationsResponse</returns>
        public TransactionsReconciliationsResponse ReconcileTransactions(TransactionReconciliationRequest transactionReconciliationRequest = default(TransactionReconciliationRequest))
        {
            Lusid.Sdk.Client.ApiResponse<TransactionsReconciliationsResponse> localVarResponse = ReconcileTransactionsWithHttpInfo(transactionReconciliationRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] ReconcileTransactions: Perform a Transactions Reconciliation. Evaluates two sets of transactions to determine which transactions from each set likely match  using the rules of a specified mapping.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="transactionReconciliationRequest"> (optional)</param>
        /// <returns>ApiResponse of TransactionsReconciliationsResponse</returns>
        public Lusid.Sdk.Client.ApiResponse<TransactionsReconciliationsResponse> ReconcileTransactionsWithHttpInfo(TransactionReconciliationRequest transactionReconciliationRequest = default(TransactionReconciliationRequest))
        {
            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json",
                "application/json",
                "text/json",
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = transactionReconciliationRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request
            var localVarResponse = this.Client.Post<TransactionsReconciliationsResponse>("/api/portfolios/$reconcileTransactions", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ReconcileTransactions", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] ReconcileTransactions: Perform a Transactions Reconciliation. Evaluates two sets of transactions to determine which transactions from each set likely match  using the rules of a specified mapping.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="transactionReconciliationRequest"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TransactionsReconciliationsResponse</returns>
        public async System.Threading.Tasks.Task<TransactionsReconciliationsResponse> ReconcileTransactionsAsync(TransactionReconciliationRequest transactionReconciliationRequest = default(TransactionReconciliationRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<TransactionsReconciliationsResponse> localVarResponse = await ReconcileTransactionsWithHttpInfoAsync(transactionReconciliationRequest, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] ReconcileTransactions: Perform a Transactions Reconciliation. Evaluates two sets of transactions to determine which transactions from each set likely match  using the rules of a specified mapping.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="transactionReconciliationRequest"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TransactionsReconciliationsResponse)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<TransactionsReconciliationsResponse>> ReconcileTransactionsWithHttpInfoAsync(TransactionReconciliationRequest transactionReconciliationRequest = default(TransactionReconciliationRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json", 
                "application/json", 
                "text/json", 
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = transactionReconciliationRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<TransactionsReconciliationsResponse>("/api/portfolios/$reconcileTransactions", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ReconcileTransactions", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] ReconcileTransactionsV2: Perform a Transactions Reconciliation. Evaluates two sets of transactions to determine which transactions from each set likely match  using the rules of a specified mapping.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="transactionReconciliationRequestV2"> (optional)</param>
        /// <returns>ReconciliationResponse</returns>
        public ReconciliationResponse ReconcileTransactionsV2(TransactionReconciliationRequestV2 transactionReconciliationRequestV2 = default(TransactionReconciliationRequestV2))
        {
            Lusid.Sdk.Client.ApiResponse<ReconciliationResponse> localVarResponse = ReconcileTransactionsV2WithHttpInfo(transactionReconciliationRequestV2);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] ReconcileTransactionsV2: Perform a Transactions Reconciliation. Evaluates two sets of transactions to determine which transactions from each set likely match  using the rules of a specified mapping.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="transactionReconciliationRequestV2"> (optional)</param>
        /// <returns>ApiResponse of ReconciliationResponse</returns>
        public Lusid.Sdk.Client.ApiResponse<ReconciliationResponse> ReconcileTransactionsV2WithHttpInfo(TransactionReconciliationRequestV2 transactionReconciliationRequestV2 = default(TransactionReconciliationRequestV2))
        {
            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json",
                "application/json",
                "text/json",
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = transactionReconciliationRequestV2;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request
            var localVarResponse = this.Client.Post<ReconciliationResponse>("/api/portfolios/$reconcileTransactionsV2", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ReconcileTransactionsV2", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] ReconcileTransactionsV2: Perform a Transactions Reconciliation. Evaluates two sets of transactions to determine which transactions from each set likely match  using the rules of a specified mapping.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="transactionReconciliationRequestV2"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ReconciliationResponse</returns>
        public async System.Threading.Tasks.Task<ReconciliationResponse> ReconcileTransactionsV2Async(TransactionReconciliationRequestV2 transactionReconciliationRequestV2 = default(TransactionReconciliationRequestV2), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<ReconciliationResponse> localVarResponse = await ReconcileTransactionsV2WithHttpInfoAsync(transactionReconciliationRequestV2, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] ReconcileTransactionsV2: Perform a Transactions Reconciliation. Evaluates two sets of transactions to determine which transactions from each set likely match  using the rules of a specified mapping.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="transactionReconciliationRequestV2"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ReconciliationResponse)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<ReconciliationResponse>> ReconcileTransactionsV2WithHttpInfoAsync(TransactionReconciliationRequestV2 transactionReconciliationRequestV2 = default(TransactionReconciliationRequestV2), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json", 
                "application/json", 
                "text/json", 
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = transactionReconciliationRequestV2;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<ReconciliationResponse>("/api/portfolios/$reconcileTransactionsV2", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ReconcileTransactionsV2", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// ReconcileValuation: Reconcile valuations performed on one or two sets of holdings using one or two configuration recipes. Perform valuation of one or two set of holdings using different one or two configuration recipes. Produce a breakdown of the resulting differences in valuation.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="valuationsReconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <returns>ListAggregationReconciliation</returns>
        public ListAggregationReconciliation ReconcileValuation(ValuationsReconciliationRequest valuationsReconciliationRequest = default(ValuationsReconciliationRequest))
        {
            Lusid.Sdk.Client.ApiResponse<ListAggregationReconciliation> localVarResponse = ReconcileValuationWithHttpInfo(valuationsReconciliationRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// ReconcileValuation: Reconcile valuations performed on one or two sets of holdings using one or two configuration recipes. Perform valuation of one or two set of holdings using different one or two configuration recipes. Produce a breakdown of the resulting differences in valuation.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="valuationsReconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <returns>ApiResponse of ListAggregationReconciliation</returns>
        public Lusid.Sdk.Client.ApiResponse<ListAggregationReconciliation> ReconcileValuationWithHttpInfo(ValuationsReconciliationRequest valuationsReconciliationRequest = default(ValuationsReconciliationRequest))
        {
            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json",
                "application/json",
                "text/json",
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = valuationsReconciliationRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request
            var localVarResponse = this.Client.Post<ListAggregationReconciliation>("/api/portfolios/$reconcileValuation", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ReconcileValuation", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// ReconcileValuation: Reconcile valuations performed on one or two sets of holdings using one or two configuration recipes. Perform valuation of one or two set of holdings using different one or two configuration recipes. Produce a breakdown of the resulting differences in valuation.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="valuationsReconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ListAggregationReconciliation</returns>
        public async System.Threading.Tasks.Task<ListAggregationReconciliation> ReconcileValuationAsync(ValuationsReconciliationRequest valuationsReconciliationRequest = default(ValuationsReconciliationRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<ListAggregationReconciliation> localVarResponse = await ReconcileValuationWithHttpInfoAsync(valuationsReconciliationRequest, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// ReconcileValuation: Reconcile valuations performed on one or two sets of holdings using one or two configuration recipes. Perform valuation of one or two set of holdings using different one or two configuration recipes. Produce a breakdown of the resulting differences in valuation.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="valuationsReconciliationRequest">The specifications of the inputs to the reconciliation (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ListAggregationReconciliation)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<ListAggregationReconciliation>> ReconcileValuationWithHttpInfoAsync(ValuationsReconciliationRequest valuationsReconciliationRequest = default(ValuationsReconciliationRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json", 
                "application/json", 
                "text/json", 
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = valuationsReconciliationRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<ListAggregationReconciliation>("/api/portfolios/$reconcileValuation", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ReconcileValuation", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpdateReconciliation: Update scheduled reconciliation Update a given scheduled reconciliation
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation to be updated</param>
        /// <param name="code">The code of the reconciliation to be updated</param>
        /// <param name="updateReconciliationRequest">The updated definition of the reconciliation (optional)</param>
        /// <returns>Reconciliation</returns>
        public Reconciliation UpdateReconciliation(string scope, string code, UpdateReconciliationRequest updateReconciliationRequest = default(UpdateReconciliationRequest))
        {
            Lusid.Sdk.Client.ApiResponse<Reconciliation> localVarResponse = UpdateReconciliationWithHttpInfo(scope, code, updateReconciliationRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpdateReconciliation: Update scheduled reconciliation Update a given scheduled reconciliation
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation to be updated</param>
        /// <param name="code">The code of the reconciliation to be updated</param>
        /// <param name="updateReconciliationRequest">The updated definition of the reconciliation (optional)</param>
        /// <returns>ApiResponse of Reconciliation</returns>
        public Lusid.Sdk.Client.ApiResponse<Reconciliation> UpdateReconciliationWithHttpInfo(string scope, string code, UpdateReconciliationRequest updateReconciliationRequest = default(UpdateReconciliationRequest))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ReconciliationsApi->UpdateReconciliation");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ReconciliationsApi->UpdateReconciliation");

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json",
                "application/json",
                "text/json",
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter
            localVarRequestOptions.Data = updateReconciliationRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request
            var localVarResponse = this.Client.Post<Reconciliation>("/api/portfolios/$scheduledReconciliations/{scope}/{code}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpdateReconciliation", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpdateReconciliation: Update scheduled reconciliation Update a given scheduled reconciliation
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation to be updated</param>
        /// <param name="code">The code of the reconciliation to be updated</param>
        /// <param name="updateReconciliationRequest">The updated definition of the reconciliation (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Reconciliation</returns>
        public async System.Threading.Tasks.Task<Reconciliation> UpdateReconciliationAsync(string scope, string code, UpdateReconciliationRequest updateReconciliationRequest = default(UpdateReconciliationRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<Reconciliation> localVarResponse = await UpdateReconciliationWithHttpInfoAsync(scope, code, updateReconciliationRequest, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpdateReconciliation: Update scheduled reconciliation Update a given scheduled reconciliation
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation to be updated</param>
        /// <param name="code">The code of the reconciliation to be updated</param>
        /// <param name="updateReconciliationRequest">The updated definition of the reconciliation (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Reconciliation)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<Reconciliation>> UpdateReconciliationWithHttpInfoAsync(string scope, string code, UpdateReconciliationRequest updateReconciliationRequest = default(UpdateReconciliationRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ReconciliationsApi->UpdateReconciliation");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ReconciliationsApi->UpdateReconciliation");


            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json", 
                "application/json", 
                "text/json", 
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter
            localVarRequestOptions.Data = updateReconciliationRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<Reconciliation>("/api/portfolios/$scheduledReconciliations/{scope}/{code}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpdateReconciliation", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpsertReconciliationBreak: Upsert a reconciliation break Update or create a given reconciliation break
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="upsertReconciliationBreakRequest">The definition of the reconciliation break request (optional)</param>
        /// <returns>ReconciliationRunBreak</returns>
        public ReconciliationRunBreak UpsertReconciliationBreak(string scope, string code, DateTimeOffset runDate, int version, UpsertReconciliationBreakRequest upsertReconciliationBreakRequest = default(UpsertReconciliationBreakRequest))
        {
            Lusid.Sdk.Client.ApiResponse<ReconciliationRunBreak> localVarResponse = UpsertReconciliationBreakWithHttpInfo(scope, code, runDate, version, upsertReconciliationBreakRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpsertReconciliationBreak: Upsert a reconciliation break Update or create a given reconciliation break
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="upsertReconciliationBreakRequest">The definition of the reconciliation break request (optional)</param>
        /// <returns>ApiResponse of ReconciliationRunBreak</returns>
        public Lusid.Sdk.Client.ApiResponse<ReconciliationRunBreak> UpsertReconciliationBreakWithHttpInfo(string scope, string code, DateTimeOffset runDate, int version, UpsertReconciliationBreakRequest upsertReconciliationBreakRequest = default(UpsertReconciliationBreakRequest))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ReconciliationsApi->UpsertReconciliationBreak");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ReconciliationsApi->UpsertReconciliationBreak");

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json",
                "application/json",
                "text/json",
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter
            localVarRequestOptions.PathParameters.Add("runDate", Lusid.Sdk.Client.ClientUtils.ParameterToString(runDate)); // path parameter
            localVarRequestOptions.PathParameters.Add("version", Lusid.Sdk.Client.ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.Data = upsertReconciliationBreakRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request
            var localVarResponse = this.Client.Post<ReconciliationRunBreak>("/api/portfolios/$scheduledReconciliations/{scope}/{code}/runs/{runDate}/{version}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpsertReconciliationBreak", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpsertReconciliationBreak: Upsert a reconciliation break Update or create a given reconciliation break
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="upsertReconciliationBreakRequest">The definition of the reconciliation break request (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ReconciliationRunBreak</returns>
        public async System.Threading.Tasks.Task<ReconciliationRunBreak> UpsertReconciliationBreakAsync(string scope, string code, DateTimeOffset runDate, int version, UpsertReconciliationBreakRequest upsertReconciliationBreakRequest = default(UpsertReconciliationBreakRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<ReconciliationRunBreak> localVarResponse = await UpsertReconciliationBreakWithHttpInfoAsync(scope, code, runDate, version, upsertReconciliationBreakRequest, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpsertReconciliationBreak: Upsert a reconciliation break Update or create a given reconciliation break
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the break</param>
        /// <param name="code">The code of the reconciliation associated with the break</param>
        /// <param name="runDate">The date of the run associated with the break</param>
        /// <param name="version">The version number of the run associated with the break</param>
        /// <param name="upsertReconciliationBreakRequest">The definition of the reconciliation break request (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ReconciliationRunBreak)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<ReconciliationRunBreak>> UpsertReconciliationBreakWithHttpInfoAsync(string scope, string code, DateTimeOffset runDate, int version, UpsertReconciliationBreakRequest upsertReconciliationBreakRequest = default(UpsertReconciliationBreakRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ReconciliationsApi->UpsertReconciliationBreak");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ReconciliationsApi->UpsertReconciliationBreak");


            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json", 
                "application/json", 
                "text/json", 
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter
            localVarRequestOptions.PathParameters.Add("runDate", Lusid.Sdk.Client.ClientUtils.ParameterToString(runDate)); // path parameter
            localVarRequestOptions.PathParameters.Add("version", Lusid.Sdk.Client.ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.Data = upsertReconciliationBreakRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<ReconciliationRunBreak>("/api/portfolios/$scheduledReconciliations/{scope}/{code}/runs/{runDate}/{version}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpsertReconciliationBreak", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] UpsertReconciliationMapping: Create or update a mapping If no mapping exists with the specified scope and code will create a new one.  Else will update the existing mapping
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mapping">The mapping to be created / updated. (optional)</param>
        /// <returns>Mapping</returns>
        public Mapping UpsertReconciliationMapping(Mapping mapping = default(Mapping))
        {
            Lusid.Sdk.Client.ApiResponse<Mapping> localVarResponse = UpsertReconciliationMappingWithHttpInfo(mapping);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] UpsertReconciliationMapping: Create or update a mapping If no mapping exists with the specified scope and code will create a new one.  Else will update the existing mapping
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mapping">The mapping to be created / updated. (optional)</param>
        /// <returns>ApiResponse of Mapping</returns>
        public Lusid.Sdk.Client.ApiResponse<Mapping> UpsertReconciliationMappingWithHttpInfo(Mapping mapping = default(Mapping))
        {
            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json",
                "application/json",
                "text/json",
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = mapping;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request
            var localVarResponse = this.Client.Post<Mapping>("/api/portfolios/mapping", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpsertReconciliationMapping", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] UpsertReconciliationMapping: Create or update a mapping If no mapping exists with the specified scope and code will create a new one.  Else will update the existing mapping
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mapping">The mapping to be created / updated. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Mapping</returns>
        public async System.Threading.Tasks.Task<Mapping> UpsertReconciliationMappingAsync(Mapping mapping = default(Mapping), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<Mapping> localVarResponse = await UpsertReconciliationMappingWithHttpInfoAsync(mapping, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] UpsertReconciliationMapping: Create or update a mapping If no mapping exists with the specified scope and code will create a new one.  Else will update the existing mapping
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mapping">The mapping to be created / updated. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Mapping)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<Mapping>> UpsertReconciliationMappingWithHttpInfoAsync(Mapping mapping = default(Mapping), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json", 
                "application/json", 
                "text/json", 
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = mapping;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<Mapping>("/api/portfolios/mapping", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpsertReconciliationMapping", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpsertReconciliationRun: Update or Create a reconciliation run Existing reconciliations will be updated, non-existing ones will be created
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the run</param>
        /// <param name="code">The code of the reconciliation associated with the run</param>
        /// <param name="upsertReconciliationRunRequest">The definition of the reconciliation run (optional)</param>
        /// <returns>ReconciliationRun</returns>
        public ReconciliationRun UpsertReconciliationRun(string scope, string code, UpsertReconciliationRunRequest upsertReconciliationRunRequest = default(UpsertReconciliationRunRequest))
        {
            Lusid.Sdk.Client.ApiResponse<ReconciliationRun> localVarResponse = UpsertReconciliationRunWithHttpInfo(scope, code, upsertReconciliationRunRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpsertReconciliationRun: Update or Create a reconciliation run Existing reconciliations will be updated, non-existing ones will be created
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the run</param>
        /// <param name="code">The code of the reconciliation associated with the run</param>
        /// <param name="upsertReconciliationRunRequest">The definition of the reconciliation run (optional)</param>
        /// <returns>ApiResponse of ReconciliationRun</returns>
        public Lusid.Sdk.Client.ApiResponse<ReconciliationRun> UpsertReconciliationRunWithHttpInfo(string scope, string code, UpsertReconciliationRunRequest upsertReconciliationRunRequest = default(UpsertReconciliationRunRequest))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ReconciliationsApi->UpsertReconciliationRun");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ReconciliationsApi->UpsertReconciliationRun");

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json",
                "application/json",
                "text/json",
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter
            localVarRequestOptions.Data = upsertReconciliationRunRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request
            var localVarResponse = this.Client.Post<ReconciliationRun>("/api/portfolios/$scheduledReconciliations/{scope}/{code}/runs", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpsertReconciliationRun", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpsertReconciliationRun: Update or Create a reconciliation run Existing reconciliations will be updated, non-existing ones will be created
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the run</param>
        /// <param name="code">The code of the reconciliation associated with the run</param>
        /// <param name="upsertReconciliationRunRequest">The definition of the reconciliation run (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ReconciliationRun</returns>
        public async System.Threading.Tasks.Task<ReconciliationRun> UpsertReconciliationRunAsync(string scope, string code, UpsertReconciliationRunRequest upsertReconciliationRunRequest = default(UpsertReconciliationRunRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<ReconciliationRun> localVarResponse = await UpsertReconciliationRunWithHttpInfoAsync(scope, code, upsertReconciliationRunRequest, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpsertReconciliationRun: Update or Create a reconciliation run Existing reconciliations will be updated, non-existing ones will be created
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the reconciliation associated with the run</param>
        /// <param name="code">The code of the reconciliation associated with the run</param>
        /// <param name="upsertReconciliationRunRequest">The definition of the reconciliation run (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ReconciliationRun)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<ReconciliationRun>> UpsertReconciliationRunWithHttpInfoAsync(string scope, string code, UpsertReconciliationRunRequest upsertReconciliationRunRequest = default(UpsertReconciliationRunRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ReconciliationsApi->UpsertReconciliationRun");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ReconciliationsApi->UpsertReconciliationRun");


            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json", 
                "application/json", 
                "text/json", 
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter
            localVarRequestOptions.Data = upsertReconciliationRunRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.158");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<ReconciliationRun>("/api/portfolios/$scheduledReconciliations/{scope}/{code}/runs", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpsertReconciliationRun", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}