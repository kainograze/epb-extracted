// 2a84840cc6f44442d81198ab56175e0c, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Gorillaz
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using LitJson;
using UnityEngine;

public class Gorillaz : MonoBehaviour
{
	[CompilerGenerated]
	private class <>c__CompilerGenerated0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		[CompilerGenerated]
		public class <>c__CompilerGenerated11
		{
			internal JsonData[] <12:game_modes>;
		}

		[CompilerGenerated]
		public class <>c__CompilerGenerated12
		{
			internal JsonData[] <13:$s_1>;

			internal int <13:$s_2>;

			internal int <13:$s_3>;

			internal JsonData <13:game_mode>;
		}

		[CompilerGenerated]
		public class <>c__CompilerGenerated13
		{
			internal IEnumerator<KeyValuePair<string, JsonData>> <14:$s_4>;

			internal KeyValuePair<string, JsonData> <14:kvp>;
		}

		[CompilerGenerated]
		public class <>c__CompilerGenerated14
		{
			internal JsonData <15:level>;
		}

		[CompilerGenerated]
		public class <>c__CompilerGenerated15
		{
			internal JsonData <16:test>;
		}

		[CompilerGenerated]
		public class <>c__CompilerGenerated16
		{
			internal int <17:s>;
		}

		[CompilerGenerated]
		public class <>c__CompilerGenerated17
		{
			internal IEnumerator<KeyValuePair<string, JsonData>> <18:$s_5>;

			internal KeyValuePair<string, JsonData> <18:kvp>;
		}

		[CompilerGenerated]
		public class <>c__CompilerGenerated18
		{
			internal JsonData <19:level>;
		}

		[CompilerGenerated]
		public class <>c__CompilerGenerated19
		{
			internal JsonData <20:test>;
		}

		[CompilerGenerated]
		public class <>c__CompilerGenerated20
		{
			internal int <21:l>;
		}

		[CompilerGenerated]
		public class <>c__CompilerGenerated21
		{
			internal int <22:s>;
		}

		[CompilerGenerated]
		public class <>c__CompilerGenerated22
		{
			internal int <23:loadLevel>;
		}

		[CompilerGenerated]
		public class <>c__CompilerGenerated23
		{
			internal IEnumerator<KeyValuePair<string, JsonData>> <24:$s_6>;

			internal KeyValuePair<string, JsonData> <24:kvp>;
		}

		[CompilerGenerated]
		public class <>c__CompilerGenerated24
		{
			internal JsonData <25:achievement>;
		}

		[CompilerGenerated]
		public class <>c__CompilerGenerated25
		{
			internal bool <26:ach_check>;
		}

		internal Gorillaz <1:<>THIS>;

		internal int $PC;

		internal object $current;

		internal <>c__CompilerGenerated16 <1:scope17>;

		internal <>c__CompilerGenerated22 <1:scope23>;

		internal <>c__CompilerGenerated20 <1:scope21>;

		internal <>c__CompilerGenerated13 <1:scope14>;

		internal <>c__CompilerGenerated19 <1:scope20>;

		internal <>c__CompilerGenerated17 <1:scope18>;

		internal <>c__CompilerGenerated23 <1:scope24>;

		internal <>c__CompilerGenerated12 <1:scope13>;

		internal <>c__CompilerGenerated14 <1:scope15>;

		internal <>c__CompilerGenerated15 <1:scope16>;

		internal <>c__CompilerGenerated21 <1:scope22>;

		internal <>c__CompilerGenerated24 <1:scope25>;

		internal <>c__CompilerGenerated25 <1:scope26>;

		internal <>c__CompilerGenerated11 <1:scope12>;

		internal <>c__CompilerGenerated18 <1:scope19>;

		object IEnumerator<object>.Current
		{
			get
			{
				if ($PC <= 0)
				{
					throw new InvalidOperationException();
				}
				return $current;
			}
		}

		object IEnumerator.Current
		{
			get
			{
				if ($PC <= 0)
				{
					throw new InvalidOperationException();
				}
				return $current;
			}
		}

		public <>c__CompilerGenerated0(int $PC, Gorillaz parent)
		{
			this.$PC = $PC;
			<1:<>THIS> = parent;
		}

		[CompilerGenerated]
		public bool MoveNext()
		{
			try
			{
				switch ($PC)
				{
				case 0:
					$current = <1:<>THIS>.loadGame;
					$PC = 1;
					return true;
				case 1:
					<1:<>THIS>.game = JsonMapper.ToObject(GorillazEncrypt.DecryptString(<1:<>THIS>.loadGame.data, <1:<>THIS>.password, <1:<>THIS>.salt));
					try
					{
						<1:<>THIS>.param_user_id = Convert.ToInt32((string)<1:<>THIS>.game["user_id"]);
					}
					catch
					{
						<1:<>THIS>.param_user_id = (int)<1:<>THIS>.game["user_id"];
					}
					finally
					{
					}
					if (<1:<>THIS>.game["username"] != null)
					{
						<1:<>THIS>.username = (string)<1:<>THIS>.game["username"];
					}
					else
					{
						<1:<>THIS>.username = "Player";
					}
					<1:<>THIS>.medal_gold = true;
					<1:<>THIS>.medal_silver = true;
					_ = 5;
					<1:scope12> = new <>c__CompilerGenerated11();
					<1:scope12>.<12:game_modes> = new JsonData[2]
					{
						<1:<>THIS>.game["gameXml"]["details"]["game_modes"]["driving"],
						<1:<>THIS>.game["gameXml"]["details"]["game_modes"]["swimming"]
					};
					_ = 6;
					<1:scope13> = new <>c__CompilerGenerated12();
					<1:scope13>.<13:$s_1> = <1:scope12>.<12:game_modes>;
					<1:scope13>.<13:$s_3> = <1:scope13>.<13:$s_1>.Length;
					<1:scope13>.<13:$s_2> = 0;
					while (<1:scope13>.<13:$s_2> < <1:scope13>.<13:$s_3>)
					{
						<1:scope13>.<13:game_mode> = <1:scope13>.<13:$s_1>[<1:scope13>.<13:$s_2>];
						_ = 7;
						<1:scope14> = new <>c__CompilerGenerated13();
						<1:scope14>.<14:$s_4> = <1:scope13>.<13:game_mode>.object_list.GetEnumerator();
						try
						{
							while (<1:scope14>.<14:$s_4>.MoveNext())
							{
								<1:scope14>.<14:kvp> = <1:scope14>.<14:$s_4>.Current;
								_ = 8;
								<1:scope15> = new <>c__CompilerGenerated14();
								<1:scope15>.<15:level> = <1:scope14>.<14:kvp>.Value;
								try
								{
									_ = 9;
									<1:scope16> = new <>c__CompilerGenerated15();
									<1:scope16>.<16:test> = <1:scope15>.<15:level>["score_mode"];
								}
								catch
								{
									_ = 10;
									<1:scope17> = new <>c__CompilerGenerated16();
									<1:scope17>.<17:s> = Convert.ToInt32((string)<1:scope15>.<15:level>["@attributes"]["best_score"]);
									<1:<>THIS>.flashscore += <1:scope17>.<17:s>;
									if (<1:scope17>.<17:s> < Convert.ToInt32((string)<1:scope15>.<15:level>["@attributes"]["medal_gold"]))
									{
										<1:<>THIS>.medal_gold = false;
										if (<1:scope17>.<17:s> < Convert.ToInt32((string)<1:scope15>.<15:level>["@attributes"]["medal_silver"]))
										{
											<1:<>THIS>.medal_silver = false;
										}
									}
								}
								finally
								{
								}
							}
						}
						finally
						{
							(<1:scope14>.<14:$s_4> as IDisposable)?.Dispose();
						}
						<1:scope13>.<13:$s_2>++;
					}
					_ = 11;
					<1:scope18> = new <>c__CompilerGenerated17();
					<1:scope18>.<18:$s_5> = <1:<>THIS>.game["gameXml"]["details"]["game_modes"]["gliding"].object_list.GetEnumerator();
					try
					{
						while (<1:scope18>.<18:$s_5>.MoveNext())
						{
							<1:scope18>.<18:kvp> = <1:scope18>.<18:$s_5>.Current;
							_ = 12;
							<1:scope19> = new <>c__CompilerGenerated18();
							<1:scope19>.<19:level> = <1:scope18>.<18:kvp>.Value;
							try
							{
								_ = 13;
								<1:scope20> = new <>c__CompilerGenerated19();
								<1:scope20>.<20:test> = <1:scope19>.<19:level>["score_mode"];
							}
							catch
							{
								_ = 14;
								<1:scope21> = new <>c__CompilerGenerated20();
								<1:scope21>.<21:l> = Convert.ToInt32((string)<1:scope19>.<19:level>["@attributes"]["level_id"]);
								<1:<>THIS>.bronze[<1:scope21>.<21:l>] = Convert.ToInt32((string)<1:scope19>.<19:level>["@attributes"]["medal_bronze"]);
								<1:<>THIS>.silver[<1:scope21>.<21:l>] = Convert.ToInt32((string)<1:scope19>.<19:level>["@attributes"]["medal_silver"]);
								<1:<>THIS>.gold[<1:scope21>.<21:l>] = Convert.ToInt32((string)<1:scope19>.<19:level>["@attributes"]["medal_gold"]);
								_ = 15;
								<1:scope22> = new <>c__CompilerGenerated21();
								<1:scope22>.<22:s> = Convert.ToInt32((string)<1:scope19>.<19:level>["@attributes"]["best_score"]);
								<1:<>THIS>.levelscore[<1:scope21>.<21:l>] = <1:scope22>.<22:s>;
								if (<1:scope22>.<22:s> < <1:<>THIS>.bronze[<1:scope21>.<21:l>])
								{
									continue;
								}
								<1:<>THIS>.ach_bronze[<1:scope21>.<21:l>] = true;
								if (<1:scope22>.<22:s> >= <1:<>THIS>.silver[<1:scope21>.<21:l>])
								{
									<1:<>THIS>.ach_silver[<1:scope21>.<21:l>] = true;
									if (<1:scope22>.<22:s> >= <1:<>THIS>.gold[<1:scope21>.<21:l>])
									{
										<1:<>THIS>.ach_gold[<1:scope21>.<21:l>] = true;
									}
								}
							}
							finally
							{
							}
						}
					}
					finally
					{
						(<1:scope18>.<18:$s_5> as IDisposable)?.Dispose();
					}
					_ = 16;
					<1:scope23> = new <>c__CompilerGenerated22();
					<1:scope23>.<23:loadLevel> = 1;
					if (<1:<>THIS>.LevelPlayable(726 + <1:<>THIS>.desiredLevel))
					{
						<1:scope23>.<23:loadLevel> += <1:<>THIS>.desiredLevel;
					}
					Application.LoadLevel(<1:scope23>.<23:loadLevel>);
					_ = 17;
					<1:scope24> = new <>c__CompilerGenerated23();
					<1:scope24>.<24:$s_6> = <1:<>THIS>.game["associatedXml"]["data"]["achievements"].object_list.GetEnumerator();
					try
					{
						while (<1:scope24>.<24:$s_6>.MoveNext())
						{
							<1:scope24>.<24:kvp> = <1:scope24>.<24:$s_6>.Current;
							_ = 18;
							<1:scope25> = new <>c__CompilerGenerated24();
							<1:scope25>.<25:achievement> = <1:scope24>.<24:kvp>.Value;
							_ = 19;
							<1:scope26> = new <>c__CompilerGenerated25();
							<1:scope26>.<26:ach_check> = true;
							if (Convert.ToInt32((string)<1:scope25>.<25:achievement>["@attributes"]["achieved"]) == 0)
							{
								<1:scope26>.<26:ach_check> = false;
							}
							<1:<>THIS>.achievements[Convert.ToInt32((string)<1:scope25>.<25:achievement>["@attributes"]["itemid"])] = <1:scope26>.<26:ach_check>;
						}
					}
					finally
					{
						(<1:scope24>.<24:$s_6> as IDisposable)?.Dispose();
					}
					<1:<>THIS>.AddAchievement(689);
					$PC = -1;
					break;
				}
				return false;
			}
			catch
			{
				//try-fault
				Dispose();
				throw;
			}
		}

		public void Dispose()
		{
			switch ($PC)
			{
			case 0:
			case 1:
				return;
			}
			$PC = -1;
		}

		public void Reset()
		{
			throw new NotSupportedException();
		}
	}

	[CompilerGenerated]
	private class <>c__CompilerGenerated1 : IEnumerator, IDisposable, IEnumerator<object>
	{
		[CompilerGenerated]
		public class <>c__CompilerGenerated26
		{
			internal JsonData <27:jsondata>;
		}

		internal Gorillaz <2:<>THIS>;

		internal int <2:level_id>;

		internal int $PC;

		internal object $current;

		internal <>c__CompilerGenerated26 <2:scope27>;

		object IEnumerator<object>.Current
		{
			get
			{
				if ($PC <= 0)
				{
					throw new InvalidOperationException();
				}
				return $current;
			}
		}

		object IEnumerator.Current
		{
			get
			{
				if ($PC <= 0)
				{
					throw new InvalidOperationException();
				}
				return $current;
			}
		}

		public <>c__CompilerGenerated1(int $PC, Gorillaz parent)
		{
			this.$PC = $PC;
			<2:<>THIS> = parent;
		}

		[CompilerGenerated]
		public bool MoveNext()
		{
			try
			{
				switch ($PC)
				{
				case 0:
					$current = <2:<>THIS>.startLevelToken;
					$PC = 1;
					return true;
				case 1:
					_ = 20;
					<2:scope27> = new <>c__CompilerGenerated26();
					<2:scope27>.<27:jsondata> = JsonMapper.ToObject(GorillazEncrypt.DecryptString(<2:<>THIS>.startLevelToken.data, <2:<>THIS>.password, <2:<>THIS>.salt));
					<2:<>THIS>.param_level_token = (string)<2:scope27>.<27:jsondata>["level_token"];
					if (<2:level_id> == 726)
					{
						<2:<>THIS>.SetGameScore(<2:<>THIS>.unityscore, 167);
					}
					$PC = -1;
					break;
				}
				return false;
			}
			catch
			{
				//try-fault
				Dispose();
				throw;
			}
		}

		public void Dispose()
		{
			switch ($PC)
			{
			case 0:
			case 1:
				return;
			}
			$PC = -1;
		}

		public void Reset()
		{
			throw new NotSupportedException();
		}
	}

	[CompilerGenerated]
	private class <>c__CompilerGenerated2 : IEnumerator, IDisposable, IEnumerator<object>
	{
		[CompilerGenerated]
		public class <>c__CompilerGenerated27
		{
			internal JsonData <28:jsondata>;
		}

		[CompilerGenerated]
		public class <>c__CompilerGenerated28
		{
			internal bool <29:bronze_submit>;
		}

		[CompilerGenerated]
		public class <>c__CompilerGenerated29
		{
			internal bool[] <30:$s_7>;

			internal int <30:$s_8>;

			internal int <30:$s_9>;

			internal bool <30:check>;
		}

		[CompilerGenerated]
		public class <>c__CompilerGenerated30
		{
			internal bool <31:silver_submit>;
		}

		[CompilerGenerated]
		public class <>c__CompilerGenerated31
		{
			internal bool[] <32:$s_10>;

			internal int <32:$s_11>;

			internal int <32:$s_12>;

			internal bool <32:check>;
		}

		[CompilerGenerated]
		public class <>c__CompilerGenerated32
		{
			internal bool <33:gold_submit>;
		}

		[CompilerGenerated]
		public class <>c__CompilerGenerated33
		{
			internal bool[] <34:$s_13>;

			internal int <34:$s_14>;

			internal int <34:$s_15>;

			internal bool <34:check>;
		}

		[CompilerGenerated]
		public class <>c__CompilerGenerated34
		{
			internal int[] <35:$s_16>;

			internal int <35:$s_17>;

			internal int <35:$s_18>;

			internal int <35:i>;
		}

		internal Gorillaz <3:<>THIS>;

		internal int <3:level_id>;

		internal int <3:score>;

		internal int $PC;

		internal object $current;

		internal <>c__CompilerGenerated28 <3:scope29>;

		internal <>c__CompilerGenerated27 <3:scope28>;

		internal <>c__CompilerGenerated33 <3:scope34>;

		internal <>c__CompilerGenerated34 <3:scope35>;

		internal <>c__CompilerGenerated32 <3:scope33>;

		internal <>c__CompilerGenerated30 <3:scope31>;

		internal <>c__CompilerGenerated31 <3:scope32>;

		internal <>c__CompilerGenerated29 <3:scope30>;

		object IEnumerator<object>.Current
		{
			get
			{
				if ($PC <= 0)
				{
					throw new InvalidOperationException();
				}
				return $current;
			}
		}

		object IEnumerator.Current
		{
			get
			{
				if ($PC <= 0)
				{
					throw new InvalidOperationException();
				}
				return $current;
			}
		}

		public <>c__CompilerGenerated2(int $PC, Gorillaz parent)
		{
			this.$PC = $PC;
			<3:<>THIS> = parent;
		}

		[CompilerGenerated]
		public bool MoveNext()
		{
			try
			{
				switch ($PC)
				{
				case 0:
					$current = <3:<>THIS>.setGameScore;
					$PC = 1;
					return true;
				case 1:
					_ = 21;
					<3:scope28> = new <>c__CompilerGenerated27();
					<3:scope28>.<28:jsondata> = JsonMapper.ToObject(GorillazEncrypt.DecryptString(<3:<>THIS>.setGameScore.data, <3:<>THIS>.password, <3:<>THIS>.salt));
					if ((bool)<3:scope28>.<28:jsondata>["success"] && <3:level_id> != 726)
					{
						if (<3:score> >= <3:<>THIS>.bronze[<3:level_id>])
						{
							if (!<3:<>THIS>.ach_bronze[<3:level_id>])
							{
								<3:<>THIS>.ach_bronze[<3:level_id>] = true;
								_ = 22;
								<3:scope29> = new <>c__CompilerGenerated28();
								<3:scope29>.<29:bronze_submit> = true;
								_ = 23;
								<3:scope30> = new <>c__CompilerGenerated29();
								<3:scope30>.<30:$s_7> = <3:<>THIS>.ach_bronze;
								<3:scope30>.<30:$s_9> = <3:scope30>.<30:$s_7>.Length;
								<3:scope30>.<30:$s_8> = 0;
								while (<3:scope30>.<30:$s_8> < <3:scope30>.<30:$s_9>)
								{
									<3:scope30>.<30:check> = <3:scope30>.<30:$s_7>[<3:scope30>.<30:$s_8>];
									if (!<3:scope30>.<30:check>)
									{
										<3:scope29>.<29:bronze_submit> = false;
									}
									<3:scope30>.<30:$s_8>++;
								}
								if (<3:scope29>.<29:bronze_submit>)
								{
									<3:<>THIS>.AddAchievement(690);
								}
							}
							if (<3:score> >= <3:<>THIS>.silver[<3:level_id>])
							{
								if (!<3:<>THIS>.ach_silver[<3:level_id>])
								{
									<3:<>THIS>.ach_silver[<3:level_id>] = true;
									if (<3:<>THIS>.medal_silver)
									{
										_ = 24;
										<3:scope31> = new <>c__CompilerGenerated30();
										<3:scope31>.<31:silver_submit> = true;
										_ = 25;
										<3:scope32> = new <>c__CompilerGenerated31();
										<3:scope32>.<32:$s_10> = <3:<>THIS>.ach_silver;
										<3:scope32>.<32:$s_12> = <3:scope32>.<32:$s_10>.Length;
										<3:scope32>.<32:$s_11> = 0;
										while (<3:scope32>.<32:$s_11> < <3:scope32>.<32:$s_12>)
										{
											<3:scope32>.<32:check> = <3:scope32>.<32:$s_10>[<3:scope32>.<32:$s_11>];
											if (!<3:scope32>.<32:check>)
											{
												<3:scope31>.<31:silver_submit> = false;
											}
											<3:scope32>.<32:$s_11>++;
										}
										if (<3:scope31>.<31:silver_submit>)
										{
											<3:<>THIS>.AddAchievement(691);
										}
									}
								}
								if (<3:score> >= <3:<>THIS>.gold[<3:level_id>] && !<3:<>THIS>.ach_gold[<3:level_id>])
								{
									<3:<>THIS>.ach_gold[<3:level_id>] = true;
									if (<3:<>THIS>.medal_gold)
									{
										_ = 26;
										<3:scope33> = new <>c__CompilerGenerated32();
										<3:scope33>.<33:gold_submit> = true;
										_ = 27;
										<3:scope34> = new <>c__CompilerGenerated33();
										<3:scope34>.<34:$s_13> = <3:<>THIS>.ach_gold;
										<3:scope34>.<34:$s_15> = <3:scope34>.<34:$s_13>.Length;
										<3:scope34>.<34:$s_14> = 0;
										while (<3:scope34>.<34:$s_14> < <3:scope34>.<34:$s_15>)
										{
											<3:scope34>.<34:check> = <3:scope34>.<34:$s_13>[<3:scope34>.<34:$s_14>];
											if (!<3:scope34>.<34:check>)
											{
												<3:scope33>.<33:gold_submit> = false;
											}
											<3:scope34>.<34:$s_14>++;
										}
										if (<3:scope33>.<33:gold_submit>)
										{
											<3:<>THIS>.AddAchievement(725);
										}
									}
								}
							}
						}
						<3:<>THIS>.levelscore[<3:level_id>] = <3:score>;
						<3:<>THIS>.unityscore = <3:<>THIS>.flashscore;
						_ = 28;
						<3:scope35> = new <>c__CompilerGenerated34();
						<3:scope35>.<35:$s_16> = <3:<>THIS>.levelscore;
						<3:scope35>.<35:$s_18> = <3:scope35>.<35:$s_16>.Length;
						<3:scope35>.<35:$s_17> = 0;
						while (<3:scope35>.<35:$s_17> < <3:scope35>.<35:$s_18>)
						{
							<3:scope35>.<35:i> = <3:scope35>.<35:$s_16>[<3:scope35>.<35:$s_17>];
							<3:<>THIS>.unityscore += <3:scope35>.<35:i>;
							<3:scope35>.<35:$s_17>++;
						}
						<3:<>THIS>.StartLevelToken(726);
					}
					$PC = -1;
					break;
				}
				return false;
			}
			catch
			{
				//try-fault
				Dispose();
				throw;
			}
		}

		public void Dispose()
		{
			switch ($PC)
			{
			case 0:
			case 1:
				return;
			}
			$PC = -1;
		}

		public void Reset()
		{
			throw new NotSupportedException();
		}
	}

	[CompilerGenerated]
	private class <>c__CompilerGenerated3 : IEnumerator, IDisposable, IEnumerator<object>
	{
		[CompilerGenerated]
		public class <>c__CompilerGenerated35
		{
			internal JsonData <36:jsondata>;
		}

		[CompilerGenerated]
		public class <>c__CompilerGenerated36
		{
			internal int <37:startach>;
		}

		[CompilerGenerated]
		public class <>c__CompilerGenerated37
		{
			internal bool <38:ach_check>;
		}

		[CompilerGenerated]
		public class <>c__CompilerGenerated38
		{
			internal int <39:i>;
		}

		internal Gorillaz <4:<>THIS>;

		internal int <4:ach_id>;

		internal int $PC;

		internal object $current;

		internal <>c__CompilerGenerated35 <4:scope36>;

		internal <>c__CompilerGenerated38 <4:scope39>;

		internal <>c__CompilerGenerated37 <4:scope38>;

		internal <>c__CompilerGenerated36 <4:scope37>;

		object IEnumerator<object>.Current
		{
			get
			{
				if ($PC <= 0)
				{
					throw new InvalidOperationException();
				}
				return $current;
			}
		}

		object IEnumerator.Current
		{
			get
			{
				if ($PC <= 0)
				{
					throw new InvalidOperationException();
				}
				return $current;
			}
		}

		public <>c__CompilerGenerated3(int $PC, Gorillaz parent)
		{
			this.$PC = $PC;
			<4:<>THIS> = parent;
		}

		[CompilerGenerated]
		public bool MoveNext()
		{
			try
			{
				switch ($PC)
				{
				case 0:
					$current = <4:<>THIS>.addAchievement;
					$PC = 1;
					return true;
				case 1:
					_ = 29;
					<4:scope36> = new <>c__CompilerGenerated35();
					<4:scope36>.<36:jsondata> = JsonMapper.ToObject(GorillazEncrypt.DecryptString(<4:<>THIS>.addAchievement.data, <4:<>THIS>.password, <4:<>THIS>.salt));
					if ((bool)<4:scope36>.<36:jsondata>["success"])
					{
						<4:<>THIS>.achievements[<4:ach_id>] = true;
						if (<4:ach_id> > 752 && <4:ach_id> < 773)
						{
							_ = 30;
							<4:scope37> = new <>c__CompilerGenerated36();
							<4:scope37>.<37:startach> = 753;
							_ = 31;
							<4:scope38> = new <>c__CompilerGenerated37();
							<4:scope38>.<38:ach_check> = true;
							_ = 32;
							<4:scope39> = new <>c__CompilerGenerated38();
							<4:scope39>.<39:i> = 0;
							while (<4:scope39>.<39:i> < 20)
							{
								if (!<4:<>THIS>.achievements[<4:scope37>.<37:startach> + <4:scope39>.<39:i>])
								{
									<4:scope38>.<38:ach_check> = false;
								}
								<4:scope39>.<39:i>++;
							}
							if (<4:scope38>.<38:ach_check>)
							{
								<4:<>THIS>.AddAchievement(681);
							}
						}
					}
					$PC = -1;
					break;
				}
				return false;
			}
			catch
			{
				//try-fault
				Dispose();
				throw;
			}
		}

		public void Dispose()
		{
			switch ($PC)
			{
			case 0:
			case 1:
				return;
			}
			$PC = -1;
		}

		public void Reset()
		{
			throw new NotSupportedException();
		}
	}

	public string username;

	private WWW loadGame;

	private WWW startLevelToken;

	private WWW setGameScore;

	private WWW addAchievement;

	private string posturl;

	private string password;

	private string salt;

	private JsonData game;

	private int[] bronze;

	private int[] silver;

	private int[] gold;

	private bool[] ach_bronze;

	private bool[] ach_silver;

	private bool[] ach_gold;

	private bool[] achievements;

	private int[] levelscore;

	private int flashscore;

	private int unityscore;

	private bool medal_silver;

	private bool medal_gold;

	private int param_user_id;

	private int param_level_id;

	private string param_game_token;

	private string param_level_token;

	private bool init;

	private int desiredLevel;

	private string Output;

	public string Error;

	private void Start()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
		if (!init)
		{
			init = true;
			posturl = "http://gorillaz.com/_api/";
			password = "somthdufuhruh043$";
			salt = "ere0-rere-jj";
			bronze = new int[1000];
			silver = new int[1000];
			gold = new int[1000];
			levelscore = new int[1000];
			ach_bronze = new bool[1000];
			ach_silver = new bool[1000];
			ach_gold = new bool[1000];
			achievements = new bool[1000];
			LoadGame();
		}
	}

	private void LoadGame()
	{
		string inputText = "loadGame";
		string inputText2 = "{\"game_id\":160}";
		string value = GorillazEncrypt.EncryptString(inputText, password, salt);
		string value2 = GorillazEncrypt.EncryptString(inputText2, password, salt);
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddField("f", value);
		wWWForm.AddField("d", value2);
		loadGame = new WWW(posturl, wWWForm);
		StartCoroutine(WaitLoadGame());
		Application.ExternalCall("unityembed");
		Application.ExternalCall("unitylevel");
	}

	private IEnumerator WaitLoadGame()
	{
		_ = 1;
		<>c__CompilerGenerated0 <>c__CompilerGenerated = new <>c__CompilerGenerated0(0, this);
		return <>c__CompilerGenerated;
	}

	private void StartLevelToken(int level_id)
	{
		if (param_user_id == 0)
		{
			printer("login first");
			return;
		}
		string inputText = "startLevelToken";
		string inputText2 = "{\"level_id\":" + level_id + "}";
		string value = GorillazEncrypt.EncryptString(inputText, password, salt);
		string value2 = GorillazEncrypt.EncryptString(inputText2, password, salt);
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddField("f", value);
		wWWForm.AddField("d", value2);
		startLevelToken = new WWW(posturl, wWWForm);
		StartCoroutine(WaitStartLevelToken(level_id));
		param_level_id = level_id;
	}

	private IEnumerator WaitStartLevelToken(int level_id)
	{
		_ = 2;
		<>c__CompilerGenerated1 <>c__CompilerGenerated = new <>c__CompilerGenerated1(0, this);
		<>c__CompilerGenerated.<2:level_id> = level_id;
		return <>c__CompilerGenerated;
	}

	private void SetGameScore(int score)
	{
		SetGameScore(score, 166);
	}

	private void SetGameScore(int score, int mode_id)
	{
		if (param_user_id == 0)
		{
			printer("login first");
			return;
		}
		if (param_level_id == 0)
		{
			printer("start level first");
			return;
		}
		if (score <= levelscore[param_level_id])
		{
			printer("already scored higher");
			return;
		}
		string inputText = "setGameScore";
		string inputText2 = "{\"game_id\":160,\"mode_id\":" + mode_id + ",\"level_id\":" + param_level_id + ",\"game_token\":\"" + param_game_token + "\",\"level_token\":\"" + param_level_token + "\",\"user_id\":" + param_user_id + ",\"score\":" + score + ",\"score_mode\":\"DESC\"}";
		string value = GorillazEncrypt.EncryptString(inputText, password, salt);
		string value2 = GorillazEncrypt.EncryptString(inputText2, password, salt);
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddField("f", value);
		wWWForm.AddField("d", value2);
		setGameScore = new WWW(posturl, wWWForm);
		StartCoroutine(WaitSetGameScore(score, param_level_id));
		param_level_id = 0;
	}

	private IEnumerator WaitSetGameScore(int score, int level_id)
	{
		_ = 3;
		<>c__CompilerGenerated2 <>c__CompilerGenerated = new <>c__CompilerGenerated2(0, this);
		<>c__CompilerGenerated.<3:level_id> = level_id;
		<>c__CompilerGenerated.<3:score> = score;
		return <>c__CompilerGenerated;
	}

	private void AddAchievement(int ach_id)
	{
		if (param_user_id == 0)
		{
			printer("login first");
			return;
		}
		if (achievements[ach_id])
		{
			printer("already achieved");
			return;
		}
		string inputText = "addAchievement";
		string inputText2 = "{\"ach_id\":" + ach_id + ",\"user_id\":" + param_user_id + "}";
		string value = GorillazEncrypt.EncryptString(inputText, password, salt);
		string value2 = GorillazEncrypt.EncryptString(inputText2, password, salt);
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddField("f", value);
		wWWForm.AddField("d", value2);
		addAchievement = new WWW(posturl, wWWForm);
		StartCoroutine(WaitAddAchievement(ach_id));
	}

	private IEnumerator WaitAddAchievement(int ach_id)
	{
		_ = 4;
		<>c__CompilerGenerated3 <>c__CompilerGenerated = new <>c__CompilerGenerated3(0, this);
		<>c__CompilerGenerated.<4:ach_id> = ach_id;
		return <>c__CompilerGenerated;
	}

	private bool LevelPlayable(int level_id)
	{
		if (level_id != 727 && (!ach_bronze[level_id - 1] || level_id > 734))
		{
			return false;
		}
		return true;
	}

	private void unityembed(string game_token)
	{
		JsonData jsonData = JsonMapper.ToObject(game_token);
		param_game_token = (string)jsonData["game_token"];
	}

	private void unitylevel(string level_id)
	{
		desiredLevel = Convert.ToInt32(level_id);
	}

	private void printer(string output)
	{
		MonoBehaviour.print(output);
		Error = output;
		Output = output;
	}
}
