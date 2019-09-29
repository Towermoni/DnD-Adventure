Class Form1

    ' ######################
    ' GAME CODE STARTS BELOW
    ' ##########################
    ' INSTRUCTIONS : HOW TO PLAY 
    ' ##########################
    ' ENTER YOUR NAME THEN CHOOSE YOUR CLASS
    ' SELECT THE "GENERATE CLASS" BUTTON TO CREATE YOUR CHARACTER
    ' WHEN YOU ARE SATISFIED WITH YOU CHARACTER, SELECTED THE "GENERATE SCENERIO" BUTTON
    ' WITH EACH SCENERIO, YOU ARE GIVEN AN INITIAL SELECTION OF 3 CHOICES
    ' PRECEEDING EACH OPTION IS A NUMBER, TYPE IN THE TEXT BOX THE NUMBER FOR WHICHEVER CHOICE YOU HAVE CHOSEN
    ' THE SCREEN WILL SEND BACK THE RESULT OF YOUR CHOICE, AND WHATEVER EFFECTS IT HAS ON YOUR CHARACTER
    ' ###############
    ' EXAMPLE OF PLAY
    ' ###############
    ' YOU APPROACH A LOCKED DOOR, YOUR OPTIONS ARE :
    ' 1. ATTEMPT TO BREAK OPEN DOOR (STR)
    ' 2. ATTEMPT TO LOCKPICK DOOR (DEX)
    ' 3. YELL FOR SOMEONE ON THE OTHER SIDE TO OPEN THE DOOR (CHA)

    ' THE PLAYER DECIDES TO ATTEMPT TO LOCKPICK THE DOOR AS HIS HIGHEST SKILL AS A ROUGE IS DEX. HE TYPES THE NUMBER 2 INTO THE 
    ' MESSAGE BOX INPUT Then PRESSES ENTER THE PROGRAM CALCULATES PERCENTAGE ROLL ALONG WITH THE VALUE OF THE CHARACTER'S 
    ' DEX ATTRIBUTE BEFORE PROJECTING THE RESULT ONTO THE SCREEN.
    ' THE PLAYER'S ATTEMPT TO LOCKPICK THE DOOR IS SUCESSFUL, THE PLAYER THEN COLLECTES 250 EXPERIENCE POINTS AND CONTINUES
    ' TO THE NEXT SCENERIO BY AGAIN SELECTING THE "SCENERIO" BUTTON

    ' ###############
    ' END OF TUTORIAL
    ' ###############


    ' #################
    'Character creation
    ' #################

    Dim selectedCharacter As New Character
    Dim selectedWeapon As New Weapon
    Dim selectedArmor As New Armor

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnAction.Enabled = False
    End Sub

    Private Sub btnClass_Click(sender As Object, e As EventArgs) Handles btnClass.Click

        If Not txtName.Text.Trim() = "" Then

            selectedCharacter.Name = txtName.Text

            Dim characterClass As String = ComboBox1.SelectedItem.ToString

            If characterClass = "Paladin" Then
                ' health
                selectedCharacter.Stats(0) = CInt(20)
                ' STR
                selectedCharacter.Stats(1) = 2
                ' DEX
                selectedCharacter.Stats(2) = 1
                ' CHA
                selectedCharacter.Stats(3) = 3
                ' INT
                selectedCharacter.Stats(4) = 1
                ' EXP
                selectedCharacter.Stats(5) = 0
                ' Level
                selectedCharacter.Stats(6) = 1
                ' Weapon Damage
                selectedWeapon.wStats(0) = 0
                ' Weapon Critical
                selectedWeapon.wStats(1) = 0
                ' Armor Protection
                selectedArmor.aStats(0) = 0

                displayStats()
            ElseIf characterClass = "Barbarian" Then
                selectedCharacter.Stats(0) = CInt(16)
                selectedCharacter.Stats(1) = 3
                selectedCharacter.Stats(2) = 2
                selectedCharacter.Stats(3) = 0
                selectedCharacter.Stats(4) = 0
                selectedCharacter.Stats(5) = 0
                selectedCharacter.Stats(6) = 1
                selectedWeapon.wStats(0) = 0
                selectedWeapon.wStats(1) = 0
                selectedArmor.aStats(0) = 0

                displayStats()
            ElseIf characterClass = "Rouge" Then
                selectedCharacter.Stats(0) = CInt(14)
                selectedCharacter.Stats(1) = 1
                selectedCharacter.Stats(2) = 3
                selectedCharacter.Stats(3) = 3
                selectedCharacter.Stats(4) = 2
                selectedCharacter.Stats(5) = 0
                selectedCharacter.Stats(6) = 1
                selectedWeapon.wStats(0) = 0
                selectedWeapon.wStats(1) = 0
                selectedArmor.aStats(0) = 0

                displayStats()
            End If

            btnAction.Enabled = True
        Else
            MsgBox("Please enter a name")
        End If

    End Sub

    ' ###################
    ' Scenerios functions
    ' ###################


    ' Scenerio Generator


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAction.Click

        Dim randomSelection = CInt(Math.Floor((5 * Rnd())))

        If randomSelection = 1 Then
            scenerio4()

        ElseIf randomSelection = 2 Then
            scenerio1()

        ElseIf randomSelection = 3 Then
            scenerio2()

        ElseIf randomSelection = 4 Then
            scenerio0()

        ElseIf randomSelection = 5 Then
            scenerio3()
        End If

        txtName.Enabled = False
        ComboBox1.Enabled = False
        btnClass.Enabled = False
    End Sub

    'Scenerio 1
    Private Sub scenerio0()
        Dim scenerioRand As Integer = 0
        scenerioSelection(scenerioRand)

    End Sub

    ' Scnerio 2 
    Private Sub scenerio1()
        Dim scenerioRand As Integer = 1
        scenerioSelection(scenerioRand)
    End Sub

    ' Scenerio 3
    Private Sub scenerio2()
        Dim scenerioRand As Integer = 2
        scenerioSelection(scenerioRand)

    End Sub

    ' Scenerio 4
    Private Sub scenerio3()
        Dim scenerioRand As Integer = 3
        scenerioSelection(scenerioRand)
    End Sub

    ' Scenerio 5
    Private Sub scenerio4()
        Dim scenerioRand As Integer = 4
        scenerioSelection(scenerioRand)
    End Sub

    ' assign health and attributes values to class labels   
    Private Sub displayStats()

        If Not selectedCharacter Is Nothing Then
            lblHealth.Text = selectedCharacter.Stats(0)
            lblSTR.Text = selectedCharacter.Stats(1)
            lblDEX.Text = selectedCharacter.Stats(2)
            lblCHA.Text = selectedCharacter.Stats(3)
            lblINT.Text = selectedCharacter.Stats(4)
            lblExp.Text = selectedCharacter.Stats(5)
            lblLevel.Text = selectedCharacter.Stats(6)
        End If
    End Sub

    ' #######################
    ' Game Functions and subs
    ' #######################

    ' Death Function 
    ' Whenever player takes damage, function checks to see if player's HP equals or is below 0

    Private Function Death()
        Dim isDead As Boolean
        If lblHealth.Text <= 0 Then
            isDead = True
        Else
            isDead = False
        End If

        If isDead Then
            MsgBox("You have perished in your adventures")
            btnAction.Enabled = False
            btnClass.Enabled = True
            End
        Else
            Return 0
        End If
    End Function

    ' input Function
    Private Function getInput()
        Dim inputNumber As String = InputBox("Enter your answer (1, 2, or 3)", "Input Box Text")
        If inputNumber = "1" Or inputNumber = "2" Or inputNumber = "3" Then
            Return inputNumber
        Else
            Dim isValid As Boolean = False
            While isValid = False
                MsgBox("Please input either a 1, 2, or 3")
                inputNumber = InputBox("Enter your answer (1, 2, or 3)", "Input Box Text")
                If inputNumber = "1" Or inputNumber = "2" Or inputNumber = "3" Then
                    isValid = True
                    Return inputNumber
                End If
            End While
        End If
    End Function

    ' Experience input Function
    Private Function experienceInput()
        Dim inputNumber As String = InputBox("Please choose one attribute To level up" + Environment.NewLine + "1. STR" + Environment.NewLine + "2. DEX" + Environment.NewLine + "3. CHA" + Environment.NewLine + "4. INT", "Input Box Text")
        If inputNumber = "1" Then
            selectedCharacter.Stats(1) = selectedCharacter.Stats(1) + 1
            lblSTR.Text = selectedCharacter.Stats(1)
            selectedCharacter.Stats(0) = selectedCharacter.Stats(0) + 4
            lblHealth.Text = selectedCharacter.Stats(0)
            selectedCharacter.Stats(5) = 0
            selectedCharacter.Stats(6) = selectedCharacter.Stats(6) + 1
            lblLevel.Text = selectedCharacter.Stats(6)
            lblExp.Text = 0
        ElseIf inputNumber = "2" Then
            selectedCharacter.Stats(2) = selectedCharacter.Stats(2) + 1
            lblDEX.Text = selectedCharacter.Stats(2)
            selectedCharacter.Stats(0) = selectedCharacter.Stats(0) + 4
            lblHealth.Text = selectedCharacter.Stats(0)
            selectedCharacter.Stats(5) = 0
            selectedCharacter.Stats(6) = selectedCharacter.Stats(6) + 1
            lblLevel.Text = selectedCharacter.Stats(6)
            lblExp.Text = 0
        ElseIf inputNumber = "3" Then
            selectedCharacter.Stats(3) = selectedCharacter.Stats(3) + 1
            lblCHA.Text = selectedCharacter.Stats(3)
            selectedCharacter.Stats(0) = selectedCharacter.Stats(0) + 4
            lblHealth.Text = selectedCharacter.Stats(0)
            selectedCharacter.Stats(5) = 0
            selectedCharacter.Stats(6) = selectedCharacter.Stats(6) + 1
            lblLevel.Text = selectedCharacter.Stats(6)
            lblExp.Text = 0
        ElseIf inputNumber = "4" Then
            selectedCharacter.Stats(4) = selectedCharacter.Stats(4) + 1
            lblINT.Text = selectedCharacter.Stats(4)
            selectedCharacter.Stats(0) = selectedCharacter.Stats(0) + 2
            lblHealth.Text = selectedCharacter.Stats(0)
            selectedCharacter.Stats(5) = 0
            selectedCharacter.Stats(6) = selectedCharacter.Stats(6) + 1
            lblLevel.Text = selectedCharacter.Stats(6)
            lblExp.Text = 0
        Else
            Dim isValid As Boolean = False
        While isValid = False
            MsgBox("Please input either a 1, 2, Or 3")
                inputNumber = InputBox("Please choose one attribute To level up" + Environment.NewLine + "1. STR" + Environment.NewLine + "2. DEX" + Environment.NewLine + "3. CHA" + Environment.NewLine + "4. INT", "Input Box Text")
                If inputNumber = "1" Then
                    isValid = True
                    selectedCharacter.Stats(1) = selectedCharacter.Stats(1) + 1
                    lblSTR.Text = selectedCharacter.Stats(1)
                    selectedCharacter.Stats(0) = selectedCharacter.Stats(0) + 2
                    lblHealth.Text = selectedCharacter.Stats(0)
                    selectedCharacter.Stats(5) = 0
                    selectedCharacter.Stats(6) = selectedCharacter.Stats(6) + 1
                    lblLevel.Text = selectedCharacter.Stats(6)
                    lblExp.Text = 0
                ElseIf inputNumber = "2" Then
                    isValid = True
                    selectedCharacter.Stats(2) = selectedCharacter.Stats(2) + 1
                    lblDEX.Text = selectedCharacter.Stats(2)
                    selectedCharacter.Stats(0) = selectedCharacter.Stats(0) + 2
                    lblHealth.Text = selectedCharacter.Stats(0)
                    selectedCharacter.Stats(5) = 0
                    selectedCharacter.Stats(6) = selectedCharacter.Stats(6) + 1
                    lblLevel.Text = selectedCharacter.Stats(6)
                    lblExp.Text = 0
                ElseIf inputNumber = "3" Then
                    isValid = True
                    selectedCharacter.Stats(3) = selectedCharacter.Stats(3) + 1
                    lblCHA.Text = selectedCharacter.Stats(3)
                    selectedCharacter.Stats(0) = selectedCharacter.Stats(0) + 2
                    lblHealth.Text = selectedCharacter.Stats(0)
                    selectedCharacter.Stats(5) = 0
                    selectedCharacter.Stats(6) = selectedCharacter.Stats(6) + 1
                    lblLevel.Text = selectedCharacter.Stats(6)
                    lblExp.Text = 0
                ElseIf inputNumber = "4" Then
                    isValid = True
                    selectedCharacter.Stats(4) = selectedCharacter.Stats(4) + 1
                    lblCHA.Text = selectedCharacter.Stats(4)
                    selectedCharacter.Stats(0) = selectedCharacter.Stats(0) + 2
                    lblHealth.Text = selectedCharacter.Stats(0)
                    selectedCharacter.Stats(5) = 0
                    selectedCharacter.Stats(6) = selectedCharacter.Stats(6) + 1
                    lblLevel.Text = selectedCharacter.Stats(6)
                    lblExp.Text = 0
                End If
            End While
        End If
    End Function

    ' ###################
    ' Experience Section
    ' ###################

    ' Is called whenever the character gains experience to determine if accumulated experience 
    ' meets or exceeds the required experience needed to level up
    Private Function levelUp(Experience)
        Dim totalExp As Integer = 1000
        If Experience >= totalExp Then
            experienceInput()
        Else
            Return 0
        End If
    End Function

    ' is called to give 250 exp to the character
    Private Function levelUp250()
        selectedCharacter.Stats(5) = selectedCharacter.Stats(5) + 250
        lblExp.Text = selectedCharacter.Stats(5)
        Dim experience As Integer = selectedCharacter.Stats(5)
        Return experience
    End Function

    ' is called to give 500 exp to the character
    Private Function levelUp500()
        selectedCharacter.Stats(5) = selectedCharacter.Stats(5) = 500
        lblExp.Text = selectedCharacter.Stats(5)
        Dim experience As Integer = selectedCharacter.Stats(5)
        Return experience
    End Function

    ' is called to give 750 exp to the character
    Private Function levelUp750()
        selectedCharacter.Stats(5) = selectedCharacter.Stats(5) + 750
        lblExp.Text = selectedCharacter.Stats(5)
        Dim experience As Integer = selectedCharacter.Stats(5)
        Return experience
    End Function

    ' Random loot generator
    ' Whenever called, function determines if the player recieves a random armor/weapon or finds nothing

    Private Function randomLoot()
        Dim randomINT As New Random
        Dim randomSelection = Int((3 * Rnd()) + 1)

        If randomSelection = 1 Then
            randomWeapon()
            lootedWeapon(randomWeapon())
        ElseIf randomSelection = 2 Then
            randomArmor()
            lootedArmor(randomArmor)
        Else
            Return 0
        End If
    End Function

    ' Whenever the player is damaged, this function is used to determine if the
    ' player's armor metigates some of the damage

    Private Sub armorProtection(healthLoss)
        Dim randomSelection = Int((3 * Rnd()) + 1)
        Dim healthDamage As Integer = healthLoss
        If selectedArmor.aStats(0) = 0 Then
            selectedCharacter.Stats(0) = selectedCharacter.Stats(0) - healthDamage
            lblHealth.Text = selectedCharacter.Stats(0)
        ElseIf randomSelection = 3 Then
            healthDamage = Math.Ceiling(healthLoss / selectedArmor.aStats(0))
            MsgBox("Your armor Protected you from some of the damage")
            selectedCharacter.Stats(0) = selectedCharacter.Stats(0) - healthDamage
            lblHealth.Text = selectedCharacter.Stats(0)
        Else
            selectedCharacter.Stats(0) = selectedCharacter.Stats(0) - healthDamage
            lblHealth.Text = selectedCharacter.Stats(0)
        End If
    End Sub


    ' ####################
    ' Armor loot seciton
    ' ####################

    Private Function randomArmor()
        Dim armor As String
        ' Dim randomINT As New Random
        ' Dim randomSelection = randomINT.Next(5)
        Dim randomSelection = Int((3 * Rnd()) + 1)

        If randomSelection = 2 Then
            armor = "Plate armor"

        ElseIf randomSelection = 3 Then
            armor = "Leather armor"

        ElseIf randomSelection = 1 Then
            armor = "Scale armor"
        Else
            Return 0
        End If

        Return armor
    End Function

    Private Sub displaySetArmorStats(armor)
        If armor = "Plate armor" Then
            selectedArmor.aStats(0) = 2
        ElseIf armor = "Leather armor" Then
            selectedArmor.aStats(0) = 1.5
        ElseIf armor = "Scale armor" Then
            selectedArmor.aStats(0) = 1.75
        End If
    End Sub

    Private Function lootedArmor(armor)
        Dim input As String
        input = InputBox("You found " + armor + " would you Like To equip it?" + Environment.NewLine + "1. Yes" + Environment.NewLine + "2. No")
        If input = "1" Then
            displaySetArmorStats(armor)
            displayArmor()
            lblArmorName.Text = armor
        ElseIf input = "2" Then
            Return 0
        Else
            Dim isValid As Boolean = False
            While isValid = False
                MsgBox("Please input either a 1 Or 2")
                input = InputBox("You found a " + armor + " would you Like To equip it?" + Environment.NewLine + "1. Yes" + Environment.NewLine + "2. No")
                If input = "1" Then
                    isValid = True
                    lblArmorName.Text = armor
                    displaySetArmorStats(armor)
                    displayArmor()
                ElseIf input = "2" Then
                    isValid = True
                    Return 0
                End If
            End While
        End If
    End Function

    Private Sub displayArmor()
        lblArmor.Text = selectedArmor.aStats(0)
    End Sub

    Private Function clearArmor()
        selectedArmor.aStats(0) = 0
        lblArmorName.Text = "*"
        lblArmor.Text = "*"
    End Function

    ' ##################
    ' Weapon / Weapon loot section
    ' ##################

    Public Function randomWeapon()
        Dim weapon As String
        Dim randomINT As New Random
        Dim randomSelection = randomINT.Next(5)

        If randomSelection = 0 Then
            weapon = "Great Sword"
            Return weapon

        ElseIf randomSelection = 1 Then
            weapon = "Long Sword"
            ' Return weapon

        ElseIf randomSelection = 2 Then
            weapon = "Dagger"
            ' Return weapon

        ElseIf randomSelection = 3 Then
            weapon = "BattleAxe"
            ' Return weapon

        ElseIf randomSelection = 4 Then
            weapon = "Bow"
            ' Return weapon

        ElseIf randomSelection = 5 Then
            weapon = "Mace"
            'Return weapon
        Else
            MsgBox(randomSelection)
        End If

        Return weapon

    End Function

    ' assigns weapons stats to weapon labels
    Private Sub displayWeaponStats()

        lblDamage.Text = selectedWeapon.wStats(0)
        lblCrit.Text = selectedWeapon.wStats(1)

    End Sub

    ' assigns numeric value to weapon's statistics
    Public Function displaySetWeaponStats(weapon)
        If weapon = "Great Sword" Then
            selectedWeapon.wStats(0) = 5
            selectedWeapon.wStats(1) = 2

        ElseIf weapon = "Long Sword" Then
            selectedWeapon.wStats(0) = 3
            selectedWeapon.wStats(1) = 1

        ElseIf weapon = "Dagger" Then
            selectedWeapon.wStats(0) = 2
            selectedWeapon.wStats(1) = 4

        ElseIf weapon = "BattleAxe" Then
            selectedWeapon.wStats(0) = 6
            selectedWeapon.wStats(1) = 1

        ElseIf weapon = "Bow" Then
            selectedWeapon.wStats(0) = 2
            selectedWeapon.wStats(1) = 3

        ElseIf weapon = "Mace" Then
            selectedWeapon.wStats(0) = 4
            selectedWeapon.wStats(1) = 1

        End If

    End Function

    Public Function lootedWeapon(Weapon)
        Dim input As String
        input = InputBox("You found a " + Weapon + " would you Like To equip it?" + Environment.NewLine + "1. Yes" + Environment.NewLine + "2. No")
        If input = "1" Then
            lblWeapon.Text = Weapon
            displaySetWeaponStats(Weapon)
            displayWeaponStats()
        ElseIf input = "2" Then
            Return 0
        Else
            Dim isValid As Boolean = False
            While isValid = False
                MsgBox("Please input either a 1 Or 2")
                input = InputBox("You found a " + Weapon + " would you Like To equip it?" + Environment.NewLine + "1. Yes" + Environment.NewLine + "2. No")
                If input = "1" Then
                    isValid = True
                    lblWeapon.Text = Weapon
                    displaySetWeaponStats(Weapon)
                    displayWeaponStats()
                ElseIf input = "2" Then
                    isValid = True
                    Return 0
                End If
            End While
        End If
    End Function

    Function clearWeapon()
        selectedWeapon.wStats(0) = 0
        selectedWeapon.wStats(1) = 0
        lblWeapon.Text = "*"
        lblDamage.Text = "*"
        lblCrit.Text = "*"
    End Function

    ' ########################
    ' Random number generators
    ' ########################

    Function randNumber()
        Return Int((2 * Rnd()) + 1)
    End Function

    Function randomWeaponGen()
        Dim critChance As Integer = Int((3 * Rnd()) + 1)
        If critChance = 1 Then
            Return Int((2 * Rnd()) + 1) + (selectedWeapon.wStats(0) * selectedWeapon.wStats(1))
        ElseIf critChance = 2 Or 3 Then
            Return Int((2 * Rnd()) + 1) + (selectedWeapon.wStats(0))
        End If
    End Function

    ' Generates one of three riddles for the ogre's riddle scenario
    Private Sub riddleGen()
        Dim riddleChance As Integer = Int((3 * Rnd()) + 1)
        Dim inputData As String
        Dim healthLoss As Integer
        If riddleChance = 1 Then
            RTxtBox.Text = "I have a head & no body, but I Do have a tail. What am I?" + Environment.NewLine + "1. All that Is left Of a horse after a troll attacks it" + Environment.NewLine + "2. A clock" + Environment.NewLine + "3. A coin"
            inputData = getInput()
            If inputData = 1 Then
                RTxtBox.Text = "The ogre laughs at your incorrect answer, he raises his club To swing at you. You manage To dodge the brunt Of the attack but are grazed by the savage swing. You lose 5 health."
                healthLoss = 5
                armorProtection(healthLoss)
                Death()
            ElseIf inputData = 2 Then
                RTxtBox.Text = "The ogre laughs at your incorrect answer, he raises his club To swing at you. You manage To dodge the brunt Of the attack but are grazed by the savage swing. You lose 5 health."
                healthLoss = 5
                armorProtection(healthLoss)
                Death()
            ElseIf inputData = 3 Then
                RTxtBox.Text = "The ogre roars In anger over your correct answer, during his outrage, you manage To sneak To the Next room."
                levelUp(levelUp750())
                randomLoot()
            End If
        ElseIf riddleChance = 2 Then
            RTxtBox.Text = "I can be made And I can be played. I can be cracked And I can be told. What am I?" + Environment.NewLine + "1. A violen" + Environment.NewLine + "2. A joke" + Environment.NewLine + "3. Love"
            inputData = getInput()
            If inputData = 1 Then
                RTxtBox.Text = "The ogre laughs at your incorrect answer, he raises his club To swing at you. You manage To dodge the brunt Of the attack but are grazed by the savage swing. You lose 5 health."
                healthLoss = 5
                armorProtection(healthLoss)
                Death()
            ElseIf inputData = 2 Then
                RTxtBox.Text = "The ogre roars In anger over your correct answer, during his outrage, you manage to sneak to the next room."
                levelUp(levelUp750())
                randomLoot()
            ElseIf inputData = 3 Then
                RTxtBox.Text = "The ogre laughs at your incorrect answer, he raises his club To swing at you. You manage To dodge the brunt Of the attack but are grazed by the savage swing. You lose 5 health."
                healthLoss = 5
                armorProtection(healthLoss)
                Death()
            End If
        ElseIf riddleChance = 3 Then
            RTxtBox.Text = "What has a soul but doesn't live and a tongue but can’t taste?" + Environment.NewLine + "1. A shoe" + Environment.NewLine + "2. A wraith" + Environment.NewLine + "3. Nothing"
            inputData = getInput()
            If inputData = 1 Then
                RTxtBox.Text = "The ogre roars in anger over your correct answer, during his outrage, you manage to sneak to the next room."
                levelUp(levelUp750())
                randomLoot()
            ElseIf inputData = 2 Then
                RTxtBox.Text = "The ogre laughs at your incorrect answer, he raises his club to swing at you. You manage to dodge the brunt of the attack but are grazed by the savage swing. You lose 5 health."
                healthLoss = 5
                armorProtection(healthLoss)
                Death()
            ElseIf inputData = 3 Then
                RTxtBox.Text = "The ogre laughs at your incorrect answer, he raises his club to swing at you. You manage to dodge the brunt of the attack but are grazed by the savage swing. You lose 5 health."
                healthLoss = 5
                armorProtection(healthLoss)
                Death()
            End If
        End If
    End Sub

    ' #########################################
    ' Scenerio section / Function implemenation
    ' #########################################

    ' This is where all the scenerios, along with their related functions, are used

    Function scenerioSelection(scenerioRand)
        Dim inputData As String
        Dim total As Integer
        Dim healthLoss As Integer

        If scenerioRand = 0 Then
            RTxtBox.Text = "You approach a sturdy oak door, you find that the door is locked, what do you do?" + Environment.NewLine + "1. Break open the door" + Environment.NewLine + "2.Lockpick the door" + Environment.NewLine + "3.Yell at the door to open"
            inputData = getInput()

            If inputData = "1" Then

                total = selectedCharacter.Stats(1) + randNumber()
                If total >= 4 Then
                    RTxtBox.Text = "After some struggle, you manage to break open the door."
                    levelUp(levelUp250())
                    randomLoot()
                Else
                    RTxtBox.Text = "You injure yourself as you break down the door, you lose 3 health points in the process."
                    healthLoss = 3
                    armorProtection(healthLoss)
                    randomLoot()
                    Death()
                End If
            ElseIf inputData = "2" Then
                total = selectedCharacter.Stats(2) + randNumber()
                If total >= 4 Then
                    RTxtBox.Text = " You manage to deftly lockpick the door open."
                    levelUp(levelUp250())
                    randomLoot()
                Else
                    RTxtBox.Text = " You manage to lockpick the door, but have strained your hand in the process, you lose 2 health."
                    healthLoss = 2
                    armorProtection(healthLoss)
                    randomLoot()
                    Death()
                End If
            ElseIf inputData = "3" Then
                total = selectedCharacter.Stats(3) + randNumber()
                If total >= 5 Then
                    RTxtBox.Text = " After a period of yelling, the door magically opens. (Probably tired of your antics!)"
                    levelUp(levelUp500())
                    randomLoot()
                Else
                    RTxtBox.Text = " After a period of yelling, the door magically opens. (Probably tired of your antics!) However, the prolonged yelling had made your health sore, you lose two health."
                    healthLoss = 2
                    armorProtection(healthLoss)
                    randomLoot()
                    Death()
                End If
            End If
        End If
        If scenerioRand = "1" Then
            RTxtBox.Text = "As you walk a narrow corridor, you nearly walk straight into a gaping chasm! How do you proceed? " + Environment.NewLine + "1. Scale across the side of the chasm" + Environment.NewLine + "2. Jump over the chasm " + Environment.NewLine + "3. Stare into the abyss to determine it's depth"
            inputData = getInput()

            If inputData = 1 Then
                total = selectedCharacter.Stats(2) + randNumber()
                If total >= 5 Then
                    RTxtBox.Text = "Clinging tightly, you manage to scale the the side and reach the saftey of the other side."
                    levelUp(levelUp500())
                    randomLoot()
                Else
                    RTxtBox.Text = " A loss grip, stumble footing, sees you falling down into the hole. Fortunatly, the hole was not as deep as previously thought, sustaining minor wounds, you press on. You lose 4 health."
                    healthLoss = 4
                    armorProtection(healthLoss)
                    Death()
                End If
            ElseIf inputData = "2" Then
                total = selectedCharacter.Stats(1) + randNumber()
                If total > 4 Then
                    RTxtBox.Text = " You easily soar over the pit, and land saftely to the other side."
                    levelUp(levelUp250())
                    randomLoot()
                Else
                    RTxtBox.Text = " You greatly overestimated your acrobatic abilities, you fall into the hole, luckily, the hole was not as deep as you thought, you lose 3 health."
                    healthLoss = 3
                    armorProtection(healthLoss)
                    Death()
                End If
            ElseIf inputData = "3" Then
                total = selectedCharacter.Stats(4) + randNumber()
                If total > 5 Then
                    RTxtBox.Text = " After focusing intently into the pit, your sharp perception reveals the pit to be an illusion, you safetly waltz over the once meanacing hole."
                    levelUp(levelUp750())
                    lootedWeapon(randomWeapon())
                Else
                    RTxtBox.Text = " As you stare into the abyss, the abyss stares back into you. The abyss is revealed to be an illusion, allowing you safe passage, however, unnerved by the experience. You lose one charisma and intelligence point."
                    selectedCharacter.Stats(3) = selectedCharacter.Stats(3) - 1
                    selectedCharacter.Stats(4) = selectedCharacter.Stats(4) - 1
                    lblCHA.Text = selectedCharacter.Stats(3)
                    lblINT.Text = selectedCharacter.Stats(4)
                End If
            End If
        End If
        If scenerioRand = 2 Then
            RTxtBox.Text = " A ogre stands in your way! The ogre proclaims you shall not pass unless his riddle is solved. You..." + Environment.NewLine + "1. Listen to his riddle" + Environment.NewLine + "2. Charge at the ogre (STR)" + Environment.NewLine + "3. Try to convince the ogre to let you pass (CHA)"
            inputData = getInput()
            If inputData = "1" Then
                riddleGen()
            ElseIf inputData = "2" Then
                total = randomWeaponGen()
                If total >= 11 Then
                    RTxtBox.Text = "Riddles are for losers has always been your motto. You charge at the ogre and strike him squarely over the head. The ogre shudders violently before slumping to the ground, you are victorious."
                    levelUp(levelUp750())
                    randomLoot()
                ElseIf total < 11 And total >= 9 Then
                    RTxtBox.Text = "The ogre swings at you, striking you on the hip, wincing, you manage to stab your weapon through the ogre's heart. The ogre's slumps back as he drifts into the darkness. You are victorious, but sustain 3 points of damage."
                    healthLoss = 3
                    armorProtection(healthLoss)
                    randomLoot()
                    levelUp(levelUp500())
                    Death()
                ElseIf total < 9 Then
                    RTxtBox.Text = "You realize too late, that charging at a 10 foot tall giant was perhaps not the wisest decision. The ogre strikes you sqaurely in the chest, as you drop on the ground the ogre laughs at you and leaves you for dead. By blind luck, you manage to survive but sustain great damage. You lose 8 health."
                    healthLoss = 8
                    armorProtection(healthLoss)
                    Death()
                End If
            End If
            If inputData = "3" Then
                total = selectedCharacter.Stats(3) + randNumber()
                If total >= 5 Then
                    RTxtBox.Text = "You convince the ogre that you are his mother's dad's uncle's Grandmother's college dormate's cousin, thus a distant relative. The ogre, respecting his blood ties, lets you pass unadulturated."
                    levelUp(levelUp750())
                    randomLoot()
                ElseIf total < 5 Then
                    RTxtBox.Text = "The ogre becomes furious over your attempt to bypass his riddle. He swings his club at you, you manage to dodge the brunt of the attack and escape to the next room, but is grazed on the shoulder during the process. You lose 3 health."
                    healthLoss = 4
                    armorProtection(healthLoss)
                    Death()
                End If
            End If
        End If
        If scenerioRand = 3 Then
            RTxtBox.Text = "A begger sits on your path. Upon closer inspection, the begger is revealed to be a haggard old woman, reeking of a putrid stench she begs for food or coin, however, you possess neither. How do you proceed?" + Environment.NewLine + "1. Tell her to bugger off (CHA)" + Environment.NewLine + "2. Distract her then pickpocket her when she isnt looking (DEX)" + Environment.NewLine + "3. Educate her on why begging in a dungeon is not a long term solution to her absolute poverty, and that she should consider pursuing higher education (INT)"
            inputData = getInput()

            If inputData = "1" Then
                total = selectedCharacter.Stats(3) + randNumber()
                If total > 3 Then
                    RTxtBox.Text = "As you brush past the Begger, she scolds you, but leaves you unsolicitated."
                    levelUp(levelUp250())
                    randomLoot()
                Else
                    RTxtBox.Text = "The beggar becomes furious at your disregard, she reveals herself to be a sorceress in disguise and strikes you with a bolt of lighting. You sustain 4 damage."
                    healthLoss = 4
                    armorProtection(healthLoss)
                    Death()
                End If
            ElseIf inputData = "2" Then
                total = selectedCharacter.Stats(2) + randNumber()
                If total > 2 Then
                    RTxtBox.Text = "You manage to snatch the beggar's purse when she was distracted. As you rifle thourgh it's content, you find nothing of value. Are you really that surprised?"
                    levelUp(levelUp250())
                Else
                    RTxtBox.Text = "The beggar catches you red-handed, and while she is powerless to stop you, your consciuos gets the better of you, you lose 1 Charisma and Dexeterity point."
                    selectedCharacter.Stats(2) = selectedCharacter.Stats(2) - 1
                    selectedCharacter.Stats(3) = selectedCharacter.Stats(3) - 1
                    lblDEX.Text = selectedCharacter.Stats(2)
                    lblCHA.Text = selectedCharacter.Stats(3)
                End If
            ElseIf inputData = "3" Then
                total = selectedCharacter.Stats(4) + randNumber()
                If total >= 5 Then
                    RTxtBox.Text = "The begger, inspired by your words, promises to apply to the nearest mages guild. Before she leaves, she gives you a item she was keeping for Self defense."
                    levelUp(levelUp750())
                    randomLoot()
                Else
                    RTxtBox.Text = "The beggar responds by stating that the current societal system of feudalism actively marginalizes people of her socio-economic background, i.e Peasants, whom are socially pressured to serve the local lord. The beggar theorizes this is done to artificially inflate the influence of fuedal lords. While you didn't understand a single thing she said, you definently feel smarter."
                End If
            End If
        End If
        If scenerioRand = 4 Then
                RTxtBox.Text = "A hoard of goblins surround you! Their leader, speaking in the common language, orders you to stand down and they will spare your life. You..." + Environment.NewLine + "1. Challenge their leader to a duel (CHA/STR)" + Environment.NewLine + "2. Try to distract the goblins with a comedy routine (DEX)" + Environment.NewLine + "3. Surrender yourself unconditionally"
                inputData = getInput()
                Dim totalStr As Integer

                If inputData = "1" Then
                    total = selectedCharacter.Stats(3) + randNumber() + 1
                    totalStr = randomWeaponGen()
                    If total >= 6 And totalStr >= 7 Then
                        RTxtBox.Text = "As you state your challenge, the goblin hoard looks to their tribe leader. The tribe leader, realizing he cannot let your challenge go unanswered, raises his axe and lunges at you. You easily outmatch the singular goblin and stike him down in a single hit. Seeing thier leader be struck down, the remaining goblins run away into the corridors. You are victorious."
                        levelUp(levelUp750())
                        randomLoot()
                    ElseIf total >= 6 And totalStr < 7 Then
                        RTxtBox.Text = "As you state your challenge, the goblin hoard looks to their tribe leader. The tribe leader, realizing he cannot let your challenge go unanswered, raises his axe and lunges at you. You are caught off guard by the goblin's speed and he strikes you squarely in the head with his hilt. As you lay unconscious, the goblins relieve you of your possesions before leaving you for dead. You lose 3 health."
                        healthLoss = 3
                        armorProtection(healthLoss)
                        clearWeapon()
                        clearArmor()
                        Death()
                    ElseIf total < 6 And totalStr >= 7 Then
                        RTxtBox.Text = "The goblins ignore your challenge and all charge at you at once. Through sheer skill, you manage to fight off the hoard, felling many goblins in your wake. Seeing their comrades fall, the goblins scramble to escape your wrath."
                        levelUp(levelUp500())
                        randomLoot()
                    ElseIf total < 6 And totalStr < 7 Then
                        RTxtBox.Text = "The goblins ignore your challenge and all charge at you at once. The hoard proves too much and you are overwhelmed. You get knocked out by a weapon's hilt and as you lay unconscious. The goblins relieve you of your possesions before leaving you for dead. You lose 5 health."
                        healthLoss = 5
                        armorProtection(healthLoss)
                        clearWeapon()
                        clearArmor()
                        Death()
                    End If
                ElseIf inputData = "2" Then
                    total = selectedCharacter.Stats(3) + randNumber()
                    If total >= 4 Then
                        RTxtBox.Text = "You pick up a couple of nearby rocks and start juggling them. The absurd act manages to distract the hoard long enough for you to discretely shuffle to the next room unscathed."
                        levelUp(levelUp250())
                        randomLoot()
                    Else
                        RTxtBox.Text = "The goblins, not buying your act, all charge at you at once. You deftly dodge most of their attacks. You manage to escape, but are harmed in the process. You lose 3 health."
                        healthLoss = 3
                        armorProtection(healthLoss)
                        Death()
                    End If
                ElseIf inputData = "3" Then
                    RTxtBox.Text = "You meekly surrender yourself. The goblins relieve you of your possesions, and staying true to their word, leave you physically unharmed. The same cannot be said for your self-esteem."
                    clearWeapon()
                    clearArmor()
                End If
            End If
    End Function

End Class

